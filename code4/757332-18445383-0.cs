            private void loading()
            {
                for (int i = 0; i < 100; i++)
                {
                    if (progressBar1.InvokeRequired)
                        progressBar1.Invoke(new Action(loading));
                    else
                        progressBar1.Value = i;
                }
            }
