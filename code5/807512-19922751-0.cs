      delegate void SetProgressBar(int percentage, bool logic);
            private void SetProgress(int percentage, bool logic)
            {
                if (progressBar.InvokeRequired)  
                {
                    SetProgressBar d = new SetProgressBar(SetProgress);
                    this.Invoke(d, new object[] { percentage, logic });
    
                }
                else
                {
                    
                    progressBar.Style = ProgressBarStyle.Blocks;
                    progressBar.Value = percentage;
                    progressBar.Text = percentage.ToString() + "%";
                  
                }
              
                 
            }
