        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private CancellationTokenSource currentCancellationSource;
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private async void Button_Click(object sender, RoutedEventArgs e)
            {
                // Enable/disabled buttons so that only one counting task runs at a time.
                this.Button_Start.IsEnabled = false;
                this.Button_Cancel.IsEnabled = true;
    
                try
                {
                    // Set up the progress event handler - this instance automatically invokes to the UI for UI updates
                    // this.ProgressBar_Progress is the progress bar control
                    IProgress<int> progress = new Progress<int>(count => this.ProgressBar_Progress.Value = count);
    
                    currentCancellationSource = new CancellationTokenSource();
                    await CountToOneHundredAsync(progress, this.currentCancellationSource.Token);
    
                    // Operation was successful. Let the user know!
                    MessageBox.Show("Done counting!");
                }
                catch (OperationCanceledException)
                {
                    // Operation was cancelled. Let the user know!
                    MessageBox.Show("Operation cancelled.");
                }
                finally
                {
                    // Reset controls in a finally block so that they ALWAYS go 
                    // back to the correct state once the counting ends, 
                    // regardless of any exceptions
                    this.Button_Start.IsEnabled = true;
                    this.Button_Cancel.IsEnabled = false;
                    this.ProgressBar_Progress.Value = 0;
    
                    // Dispose of the cancellation source as it is no longer needed
                    this.currentCancellationSource.Dispose();
                    this.currentCancellationSource = null;
                }
            }
    
            private async Task CountToOneHundredAsync(IProgress<int> progress, CancellationToken cancellationToken)
            {
                for (int i = 1; i <= 100; i++)
                {
                    // This is where the 'work' is performed. 
                    // Feel free to swap out Task.Delay for your own Task-returning code! 
                    // You can even await many tasks here
                    // ConfigureAwait(false) tells the task that we dont need to come back to the UI after awaiting
                    // This is a good read on the subject - https://blog.stephencleary.com/2012/07/dont-block-on-async-code.html
                    await Task.Delay(100, cancellationToken).ConfigureAwait(false);
    
                    // If cancelled, an exception will be thrown by the call the task.Delay
                    // and will bubble up to the calling method because we used await!
    
                    // Report progress with the current number
                    progress.Report(i);
                }
            }
    
            private void Button_Cancel_Click(object sender, RoutedEventArgs e)
            {
                // Cancel the cancellation token
                this.currentCancellationSource.Cancel();
            }
        }
