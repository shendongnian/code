        private void TestButton_Click(object sender, EventArgs e)
        {
            ThreadStart ts = new ThreadStart(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    /* Start invoking UI object */
                    MethodInvoker action = delegate
                    {
                        label1.Text = i + "";
                    };
                    label1.BeginInvoke(action);
                    /* End invoking */
                    Thread.Sleep(1000);
                }
            });
            new Thread(ts).Start();
        }
