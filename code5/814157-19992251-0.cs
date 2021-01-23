    public class MyForm: Form
    {
       public TransactionViewerViewModel TransactionViewer {get;set;}
       //... other code...
       //Form constructor:
       public MyForm()
       {
           InitializeComponent();
            
          //Create ViewModel:
          TransactionViewer = new TransactionViewerViewModel();
       }
       private void openTransactionViewToolStripMenuItem_Click(object sender, EventArgs e)
       {
          //Create WPF View:
          var transactionViewWindow = new TransactionViewer.MainWindow();
         
          //Interop code
          ElementHost.EnableModelessKeyboardInterop(transactionViewWindow);
    
          //Set DataContext:
          transactionViewWindow.DataContext = TransactionViewer;     
    
          //Show Window:
          transactionViewWindow.Show();
    
          //Call methods on the ViewModel, rather than the View:
          TransactionViewer.Test = "test";   // testing out data passing
          TransactionViewer.AddTest();
       }
    }
