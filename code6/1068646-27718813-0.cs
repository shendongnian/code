    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        Cursor.Current = Cursors.WaitCursor;
        try
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            // Confirm user wants to close
            switch (MessageBox.Show(this, "\tAre you sure you want to close ?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }
        finally
        {
            Cursor.Current = Cursors.Default;
        }
    }
