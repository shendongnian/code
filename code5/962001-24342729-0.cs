    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Right)
            System.Diagnostics.Debug.WriteLine("Right key pressed");
        return true;
    }
