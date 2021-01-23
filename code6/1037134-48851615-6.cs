    public class MyObjEntitySerializer : DefaultStreamAwareEntityTypeSerializer<MyObj>
    {
        public MyObjEntitySerializer(ODataSerializerProvider serializerProvider) : base(serializerProvider)
        {
        }
        public override Uri BuildLinkForStreamProperty(MyObj entity, EntityInstanceContext context)
        {
            var url = new UrlHelper(context.Request);
            string id = string.Format("?id={0}", entity.Id);
            var routeParams = new { id }; // add other params here
            return new Uri(url.Link("myobjdownload", routeParams), UriKind.Absolute);            
        }
        public override string ContentType
        {
            get { return "application/pdf"; }            
        }
    }
