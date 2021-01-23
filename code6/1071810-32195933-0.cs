        private string text = "";
        private object lockObject = new object();
        private void MyThread()
        {
            while (true)
            {
                lock (lockObject)
                {
                    // That can be any code that calculates text variable,
                    // I'm using DateTime for demonstration:
                    text = DateTime.Now.ToString();
                }
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            lock(lockObject)
            {
                label.Text = text;
            }
        }
