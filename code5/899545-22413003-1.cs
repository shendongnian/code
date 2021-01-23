    protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.H)
            {
                this.Close();
                return true;
            }
            else if (keyData == Keys.Alt | keyData == Keys.F4)
            {
                return base.ProcessDialogKey(keyData);
            }
            return true;
        }
