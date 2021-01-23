    using System.IO;
    using System.ServiceModel.Web;
    using System.Text;
    
    namespace WcfService1
    {
        public class Service : IService
        {
            public Stream SayHello()
            {
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
                return new MemoryStream(Encoding.UTF8.GetBytes("hello"));
            }
        }
    }
