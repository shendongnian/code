    public void UpdateStatusBarUp(string status)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    UpdateStatusBarUp(status);
                });
            }
            else
            {
                toolStripStatusLabelUp.Text = status;
                statusStripUp.Refresh();
            }
        }
