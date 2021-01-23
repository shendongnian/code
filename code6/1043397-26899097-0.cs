    using System.ServiceModel;
    namespace ClassLibrary1
    {
        public class WCFServiceLibrary1 : IWCFServiceLibrary1
        {
            [OperationContract]
            public string GetData(string value)
            {
                return string.Format("You entered: {0}", value);
            }
        }
    }
