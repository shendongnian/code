    public sealed class DocumentStoreWrapper
    {
      private readonly Task<DocumentStore> _documentStore;
      public DocumentStoreWrapper(Data data)
      {
        _documentStore = CreateDocumentStoreAsync(data);
      }
      private static async Task<DocumentStore> CreateDocumentStoreAsync(Data data)
      {
        var result = new DocumentStore();
        await documentStore.InitializeAsync(data);
        ...
        return result;
      }
      public Task<DocumentStore> DocumentStoreTask { get { return _documentStore; } }
    }
    protected void Application_Start()
    {
      var someFakeData = LoadSomeFakeData();
      var documentStoreWrapper = new DocumentStoreWrapper(someFakeData);
      ...
      // Registers this database wrapper as a singleton.
      Container.Register(documentStoreWrapper);
    }
