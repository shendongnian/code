    namespace dbg
    {
        public class CustomObjectSource
            : Microsoft.VisualStudio.DebuggerVisualizers.VisualizerObjectSource
        {
            private static object ConvertObject(object oldObj)
            {
                if (oldObj == null)
                    return null;
                foreach (var intf in oldObj.GetType().GetInterfaces())
                {
                    var prop = intf.GetProperty("DebugVisualizer");
                    if (prop != null)
                        return prop.GetValue(oldObj, null);
                }
                return oldObj;
            }
            public override void TransferData(object target, Stream incomingData, Stream outgoingData)
            {
                base.TransferData(ConvertObject(target), incomingData, outgoingData);
            }
            public override object CreateReplacementObject(object target, Stream incomingData)
            {
                return ConvertObject(base.CreateReplacementObject(ConvertObject(target), incomingData));
            }
            public override void GetData(object target, Stream outgoingData)
            {
                base.GetData(ConvertObject(target), outgoingData);
            }
        }
    }
