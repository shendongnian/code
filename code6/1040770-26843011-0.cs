    namespace WebApplication1
    {
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        public class Update : WebService
        {
            [WebMethod]
            public void ReceiveStatusUpdate(Object StatusUpdate)
            {
                var reference = StatusUpdate.Reference;
                var thirdPartyReference = StatusUpdate.ThirdPartyReference;
                var status = StatusUpdate.Status;
            }
            public class Object
            {
                public string Reference;
                public string ThirdPartyReference;
                public string Status;
            }
        }
    }
