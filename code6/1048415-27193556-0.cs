    public static void CreatePortableFile(List<MyViewModelVM> myViewModels, string path)
    {
    
        FixedDocument fixedDoc = new FixedDocument();
    
        foreach (MyViewModelVM item in myViewModels)
        {
            //idem
        }
    
        DocumentViewer dummy = new DocumentViewer(); //it's the key
        dummy.Document = fixedDoc; //it's the key
    
        Dispatcher.CurrentDispatcher.Invoke (new Action (delegate { }), DispatcherPriority.ApplicationIdle, null);
    
        WriteToXps(path, fixedDoc)
    }   
