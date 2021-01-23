    public class PermanentRemoveContentHandler : ContentHandler
    {
        private readonly IOrchardServices _orchardServices;
        public PermanentDeleteContentHandler(IOrchardServices orchardServices)
        {
            this._orchardServices = orchardServices;
        }
        protected override void Removed(RemoveContentContext context)
        {
            this._orchardServices.ContentManager.Destroy(context.ContentItem);
        }
    }
