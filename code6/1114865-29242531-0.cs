        public static bool _isRunning = false;
        private void button1_Click(object sender, EventArgs e)
        {
            _isRunning = true;
            var thread = new Thread(DoWork) {IsBackground = true};
            thread.Start();
            while (_isRunning)
            {
                //HERE GOES THE MAGIC
                Application.DoEvents();
            }
        }
        private static void DoWork()
        {
            System.Threading.Thread.Sleep(20000);
            _isRunning = false;
        }
