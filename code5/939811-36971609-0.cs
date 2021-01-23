    private void cboProfile_MouseWheel(object sender, MouseEventArgs e)
    {
        if (sender == cboProfile)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
    }
