     index++;
            //replay gif 
            millisecondi++;
            if (millisecondi == 1000)
            {
                if (progressBar1.InvokeRequired)
                {
                    progressBar1.Invoke((MethodInvoker)
                        delegate
                        {
                            progressBar1.Value = progressBar1.Value - 1;
                        }
                        );
                }
                else
                {
                    progressBar1.Value = progressBar1.Value - 1;
                }
                if (progressBar1.Value <= 0)
                {
                    MessageBox.Show("Sei Morto");
                }
            }
