    public void MainWindow()
    {
    
         InitializeComponents();
         this.DataContext = new DocumentsCollectionViewModel();
         //Initialize the collection inside your VM
    }
