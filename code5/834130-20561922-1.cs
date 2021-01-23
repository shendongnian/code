        private bool cancelled;
        private bool started;
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (started) return;
            cancelled = false;
            started = true;
            try
            {
                await DoAsync();
            }
            catch (Exception exception)
            {
                lblProgress.Content = "Error: " + exception.Message;
                return;
            }
            finally
            {
                started = false;
            }
            lblProgress.Content = cancelled ? "Cancel !" : "Finish !";
        }
        private async Task DoAsync()
        {
            using (var sr = new StreamReader("C:\\File 1.txt"))
            {
                using (var sw = new StreamWriter("C:\\Out-File 1.txt"))
                {
                    var fi = new FileInfo("C:\\File 1.txt");
                    long total = (char) fi.Length;
                    int i = 0;
                    string result;
                    while (!sr.EndOfStream)
                    {
                        result = await sr.ReadLineAsync();
                        await sw.WriteLineAsync(result);
                        i = i + (char) result.Length;
                        ProgressChanged((int) ((decimal) i/(decimal) total*(decimal) 100));
                        if (cancelled) return;
                    }
                }
            }
        }
        private void ProgressChanged(int progress)
        {
            this.lblProgress.Content = progress.ToString() + "%";
            this.pb.Value = progress;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            cancelled = true;
        }
