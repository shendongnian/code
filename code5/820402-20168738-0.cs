     namespace WindowsFormsApplication1
      {
       public partial class Form1 : Form
       {
          public Form1()
        {
            InitializeComponent();           
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int allBooksNumber = BookAgent.CountAllBooks();
            e.Result = allBooksNumber;  
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
             backgroundWorker1.RunWorkerAsync();
             label1.Text = "Loading....";
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Text = e.Result.ToString;  
        }
    }
