    private bool IfSeen;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (IfSeen)
            {
                if (keyData == (Keys.Control | Keys.I))
                {
                    MessageBox.Show("You pressed Ctrl+L+I");
                }
                IfSeen= false;
                return true;
            }
            if (keyData == (Keys.Control | Keys.L))
            {
                IfSeen= true;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
