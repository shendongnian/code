    using System;
    using System.Threading.Tasks;
    using System.Windows;
    
    namespace WpfApplication_22369179
    {
        public partial class MainWindow : Window
        {
            Task _task;
    
            public MainWindow()
            {
                InitializeComponent();
    
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
    
                _task = DoAsync();
            }
    
            async Task DoAsync()
            {
                await Task.Delay(1000);
    
                MessageBox.Show("Before throwing...");
    
                GCAsync(); // fire-and-forget the GC
    
                throw new ApplicationException("Surprise");
            }
    
            async void GCAsync()
            {
                await Task.Delay(1000);
    
                MessageBox.Show("Before GC...");
                // garbage-collect the task without observing its exception 
                _task = null;
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            }
    
            void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
            {
                MessageBox.Show("TaskScheduler_UnobservedTaskException:" + e.Exception.Message);
            }
    
            void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
            {
                MessageBox.Show("CurrentDomain_UnhandledException:" + ((Exception)e.ExceptionObject).Message);
            }
        }
    }
