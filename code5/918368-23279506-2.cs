    public interface IMetaWeblog
    {
        [XmlRpcMethod("blog.index")]
        string Index();        
    }
    public class MetaWeblogHandler : XmlRpcService, IMetaWeblog
    {
        string IMetaWeblog.Index()
        {
            return "Hello World";
        }        
    }
    public class MetaWeblogRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new MetaWeblogHandler();
        }
    }
