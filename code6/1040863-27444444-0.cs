        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);
            var a = Test1("a");
            Thread.Sleep(1000);
            var b = (string)Invoke(new Func<string>(() => Test2("b")));
            MessageBox.Show(a + b);
        }
        private string Test1(string text)
        {
            if (this.InvokeRequired)
                return (string)this.Invoke(new Func<string>(() => Test1(text)));
            else
            {
                MessageBox.Show(text);
                return "test1";
            }
        }
        private string Test2(string text)
        {
            MessageBox.Show(text);
            return "test2";
        }
