    public class FieldUpdateEventHandler  : IFieldStorageEvents {
        public void SetCalled(FieldStorageEventContext context) {
            context.Content.ContentItem.VersionRecord.Published = false;
        }
    }
