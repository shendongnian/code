    [Serializable]
    public class CommandObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            if (target != null && target is DbCommand)
            {
                DbCommand command = (DbCommand)target;
                var writer = new StreamWriter(outgoingData);
                writer.WriteLine(command.CommandText);
                writer.Flush();
            }
        }
    }
