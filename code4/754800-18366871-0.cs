    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
         if (keyData == Keys.Right)
        {
            numericUpDown1.Value = Convert.ToDecimal(numericUpDown1.Value + 1);
            return true;
        }
         if (keyData == Keys.Left)
        {
            try
            {
                numericUpDown1.Value = Convert.ToDecimal(numericUpDown1.Value - 1);
                return true;
            }
            catch { }
        }
    }
