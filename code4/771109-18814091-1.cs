    public class MyGUI
    {
       readonly MyWorkerClass worker;
    
       public MyGUI()
       {
          this.worker = new MyWorkerClass();
          this.worker.Changed += OnWorkerChanged;
       }
     
       public void OnWorkerChanged(object sender, ProgressChangedEventArgs args)
       {
          // ToDo: use args.ProgressPercentage to update a GUI element (example: ProgressBar)
          // Remark: make sure you are in the GUI thread. Use this.InvokeRequired to check
       }
    }
