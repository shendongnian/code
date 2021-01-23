    // this is the base class for tab view models
    public class DocumentViewModel
    {
        public void SaveChanges() {}
    }
    
    // this is the view model for tab container
    public class EditorViewModel
    {
        private SaveChanges()
        {
            foreach (var document in OpenedDocuments)
            {
                document.SaveChanges();
            }        
        }
    
        public EditorViewModel()
        {
            SaveCommand = new RelayCommand(SaveChanges);
        }
    
        // this is your tabs
        public ObservableCollection<DocumentViewModel> OpenedDocuments { get; private set; }
    
        public ICommand SaveChangesCommand { get; private set; }
    }
