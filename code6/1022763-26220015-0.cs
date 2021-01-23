        public bool IsDisposed;
        private void securityCheck()
                {
                    if (MyGlobals.FormCheck("RUN_JOBS") == 1)
                    {
                        InitializeComponent();
                    }
                    else
                    {
                        //this.BeginInvoke(new MethodInvoker(this.Close));
                        //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        MessageBox.Show("You do not have permission to access this form!");
                        //this.Close();
                        this.Dispose();
                        this.IsDisposed = true;
                    }      
      
            }
