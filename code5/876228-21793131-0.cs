        private bool _isFormClosing;
        void Form1Closing(object sender, CancelEventArgs e)
        {
            if (_form3 == null) return;
            e.Cancel = true;
            if (!_isFormClosing)
            {
                _isFormClosing = true;
                Task.Factory.StartNew((() =>
                {
                    while (_form3 != null)
                    {
                        Thread.Sleep(50);
                    }
                    ExecuteActionInUiThread(Close);
                }));
            }
        }
