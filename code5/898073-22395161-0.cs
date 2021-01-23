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
    
                throw new ApplicationException("Surprise");
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
