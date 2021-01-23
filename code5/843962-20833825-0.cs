    public int Woo
    {
        get
        {
           _Woo;
        }
        set
        {
           BackgroundWorker backgroundWorker = new BackgroundWorker();
           //DoWork is ran on separate thread and does not block UI
           backgroundWorker.DoWork += (sender, arguments) =>
           {
               arguments.Result = model.GetWoo(); //Store data in worker result
           }
           //This method runs definitely on UI
           backgroundWorker.RunWorkerCompleted += (sender, arguments) =>
           {
               //Get stored result and assign to UI-bound stuff
               _Woo = arguments.Result; 
               NotifyPropertyChange("Woo");
           }      
           backgroundWorker.RunWorkerAsync(); 
       }
    }
