    class BaseStorage
    {
        protected BaseStorage(IStorageItem storageItem)
        {
            this.Name = storageItem.Name;
            this.CreationDate = storageItem.DateCreated.ToString();
    
            Initialization = setModifiedDateAndOwner(storageItem);
        }
    
        protected Task Initialization { get; private set; }
    
        private async Task setModifiedDateAndOwner(IStorageItem storageItem)
        {
            …
        }
    }
    class Document : BaseStorage
    {
        private Document(IStorageFile storageFile)
            : base(storageFile)
        { }
        public static async Task<Document> Create(IStorageFile storageFile)
        {
            var result = new Document(storageFile);
            await result.Initialization;
            return result;
        }
    }
