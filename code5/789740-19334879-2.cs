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
            }
            private void UserControl_Loaded(object sender, RoutedEventArgs e)
            {
                backgroundWorker.RunWorkerAsync();
            }
            private void ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                progressBar.Value = e.ProgressPercentage;
            }
            private void DoWork(object sender, DoWorkEventArgs e)
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(100);
                    backgroundWorker.ReportProgress(i);
                }
            }
        }
    }
