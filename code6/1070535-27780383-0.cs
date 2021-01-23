        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 0; i < 10000; i++)
            {
                if (textBoxOutput.InvokeRequired)
                {
                    textBoxOutput.Invoke(new MethodInvoker(delegate
                    {
                        textBoxOutput.AppendText(i + Environment.NewLine);
                    }));
                }
            }
        }
