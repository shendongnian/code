    private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {        
                int progress = int.Parse(utilityVideo.Progress.ToString("0"));
                if (progress > 0)
                {
                    RefreshProgressBar(Progress);
                }
            }                
        }
        catch { }
        }
    private void RefreshProgressBar(int currentTimeProcessed)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { RefreshProgressBar(currentTimeProcessed); });
                return;
            }
            progressBar1.Value = currentTimeProcessed;
        }
