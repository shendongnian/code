            private void UpdateTitle(string newTitle)
            {         
                if (this.lblTitle.InvokeRequired)
                {
                    this.lblTitle.BeginInvoke((MethodInvoker) delegate() { this.lblTitle.Text = newTitle; });    
                }
                else
                {
                    this.lblTitle.Text = newTitle;
                }
            }
