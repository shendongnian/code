        private void btn_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            btn.Enabled = false;
            MyBackgroundWorker bgw = new MyBackgroundWorker(btn);
            if (btn == btnOne) {
                bgw.DoWork += bgw_DoWork_One;
            } else if (btn == btnTwo) {
                bgw.DoWork += bgw_DoWork_Two;
            }
            //...
            bgw.RunWorkerAsync(); // button enabled when completed
        }
        private void bgw_DoWork_One(object sender, DoWorkEventArgs e) {
            // button 1 statements
        }
        private void bgw_DoWork_Two(object sender, DoWorkEventArgs e) {
            // button 2 statements
        }
        public class MyBackgroundWorker : BackgroundWorker {
            protected Button btn;
            public MyBackgroundWorker(Button btn) : base() {
                this.btn = btn;
                this.btn.Enabled = false;
                this.RunWorkerCompleted += bgw_RunWorkerCompleted;
            }
            private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
                btn.Enabled = true;
            }
        }
