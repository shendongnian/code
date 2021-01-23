        public delegate void UpdateStatusDelegate();
        private bool _bWorking = false;
        private void SetStatus(bool bEnable)
        {
            if (bEnable)
            {
                tbName.IsReadOnly = false;
                barStatus.Visibility = Visibility.Hidden;
                btnStart.IsEnabled = true;
                btnStop.IsEnabled = false;
                btnClose.IsEnabled = true;
            }
            else
            {
                tbName.IsReadOnly = true;
                barStatus.Visibility = Visibility.Visible;
                btnStart.IsEnabled = false;
                btnStop.IsEnabled = true;
                btnClose.IsEnabled = false;
            }
        }
        
        internal void UpdateStatus()
        {
            SetStatus(true);
        }
        private void ThreadFunc()
        {
            try
            {
                // use Stopwatch to simulate jobs
                var watch = Stopwatch.StartNew();
                for (; ; )
                {
                    var elapsedMs = watch.ElapsedMilliseconds;
                    if (elapsedMs > 10000 // 10 seconds
                        || _bWorking == false)
                    {
                        break;
                    }
                }
                watch.Stop();
                this.Dispatcher.Invoke(new UpdateStatusDelegate(UpdateStatus));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            _bWorking = false;
        }
		
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _bWorking = true;
                SetStatus(false);
                Thread t = new Thread(new ThreadStart(() =>
                {
                    ThreadFunc();
                }));
                t.IsBackground = true;
                t.Name = "test status";
                t.Start();
                //while (t.IsAlive)
                {
                    // wait thread exit
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            _bWorking = false;
            SetStatus(true);
        }
