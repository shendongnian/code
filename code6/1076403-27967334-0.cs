    public interface IContentManagerFacade
    {
        ContentData GetItem(long id, bool returnMetadata);
    }
    public class ContentManagerFacade : IContentManagerFacade
    {
        public ContentData GetItem(long id, bool returnMetadata)
        {
            var cm = new ContentManager();
            return cm.GetItem(id, returnMetadata);
        }
    }
