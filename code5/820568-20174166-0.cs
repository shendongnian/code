    using System.ComponentModel;
    using System.Threading;
    public partial class Form1 : Form
    {
    public Form1()
    {
        InitializeComponent();
    }
	private void Form1_Load(object sender, System.EventArgs e)
	{
	    // Start the BackgroundWorker.
	    backgroundWorker1.RunWorkerAsync();
	}
	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
            // begin reading your file here...
            
            // set the progress bar value and report it to the main UI
            int i = 0; // value between 0~100
            backgroundWorker1.ReportProgress(i);
	}
	private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
	    // Change the value of the ProgressBar to the BackgroundWorker progress.
	    progressBar1.Value = e.ProgressPercentage;
	    // Set the text.
	    this.Text = e.ProgressPercentage.ToString();
	}
    }
