    public class MyMapper : WebContentTypeMapper
    {
        public override WebContentFormat GetMessageFormatForContentType(string contentType)
        {
            return WebContentFormat.Raw; // always
        }
    }
    static Binding GetBinding()
    {
        CustomBinding result = new CustomBinding(new WebHttpBinding());
        WebMessageEncodingBindingElement webMEBE = result.Elements.Find<WebMessageEncodingBindingElement>();
        webMEBE.ContentTypeMapper = new MyMapper();
        return result;
    }
