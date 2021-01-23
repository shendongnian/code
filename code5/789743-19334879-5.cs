    using System.ComponentModel;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    namespace WpfApplication1.Views
    {
        public partial class TestView : UserControl
        {
            private BackgroundWorker backgroundWorker = new BackgroundWorker();
            public TestView()
            {
                InitializeComponent();
                backgroundWorker.WorkerReportsProgress = true;
                backgroundWorker.ProgressChanged += ProgressChanged;
                backgroundWorker.DoWork += DoWork;
                // not required for this question, but is a helpful event to handle
                backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            }
            private void UserControl_Loaded(object sender, RoutedEventArgs e)
            {
                backgroundWorker.RunWorkerAsync();
            }
            private void DoWork(object sender, DoWorkEventArgs e)
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(100);
                    backgroundWorker.ReportProgress(i);
                }
            }
            private void ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                // This is called on the UI thread when ReportProgress method is called
                progressBar.Value = e.ProgressPercentage;
            }
            private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                // This is called on the UI thread when the DoWork method completes
                // so it's a good place to hide busy indicators, or put clean up code
            }
        }
    }
