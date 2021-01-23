    public class MainForm : Form
    {
      private IDocumentStore _store = new EmbeddableDocumentStore {RunInMemory = false };
      private IBookRepository _repository;
    
      private async void MainForm_Load(object sender, EventArgs args)
      {
        // Do stuff here that does not depend on _store or _repository.
        await InitializeRepositoryAsync();
        // Now you can use _store and _repository here.
      }
    
      private Task InitializeRepositoryAsync()
      {
        return Task.Run(
          () =>
          {
            _store.Initialize();
            _repository = new RavenDbBookRepository(_store);
          };
      }
    }
