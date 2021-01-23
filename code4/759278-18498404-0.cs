    public partial class Form1 : Form
    {
      public Form1()
      {
        InitializeComponent();
      }
      private void button1_Click(object sender, EventArgs e)
      {
        if (backgroundWorker1.IsBusy)
        {
          label1.Text = "Reset!";
          backgroundWorker1.CancelAsync();
          return;
        }
        backgroundWorker1.RunWorkerAsync();
      }
      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
      {
        label1.InvokeIfRequired(() => label1.Text = "Gettin busy");
        System.Threading.Thread.Sleep(5000);
        for (int i = 0; i < 10; i++)
        {
          backgroundWorker1.ReportProgress(i*10);
          System.Threading.Thread.Sleep(1000);
        }
      }
      private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
        label1.InvokeIfRequired(() => label1.Text = "Done");
      }
      private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
      {
        label1.InvokeIfRequired(() => label1.Text = string.Format("{0}% done", e.ProgressPercentage));
      }
    }
    public static class InvokeExtensions
    {
      public static void InvokeIfRequired(this ISynchronizeInvoke control, MethodInvoker action)
      {
        if (control.InvokeRequired)
        {
          control.Invoke(action, null);
        }
        else
        {
          action();
        }
      }
    }
