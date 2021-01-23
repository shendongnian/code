     protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!this.ProcessKey(msg, keyData))
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
            return false;
        }
        protected virtual bool ProcessKey(Message msg,Keys keyData)
        {
            if ((keyData & Keys.Enter) == Keys.Enter)
            {
                Label1.Text = "Enter Key";
                return true;
            }
            if ((keyData & Keys.Tab) == Keys.Tab)
            {
                Label1.Text = "Tab Key";
                return true;
            }
            return false;
        }
