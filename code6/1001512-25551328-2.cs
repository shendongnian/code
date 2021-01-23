    public class BaseModel : RenderModel
    {
        public BaseModel() :
          base(UmbracoContext.Current.PublishedContentRequest.PublishedContent) { }
    }
