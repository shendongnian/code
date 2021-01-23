        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "You guessed the correct number. Program is exiting";
            label1.BackColor = Color.LightGreen;
            Task.Factory.StartNew(Sleep).ContinueWith(t => Exit());
        }
        private void Sleep()
        {
            Thread.Sleep(2000);
        }
        private void Exit()
        {
            Environment.Exit(-1);
        }
