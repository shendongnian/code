    public static DialogResult Show(IWin32Window owner, PSSettings.Settings settings, string title, string caption, MessageBoxButtons buttons)
    {
        DialogResult result;
        
        ((Form)owner).Invoke((Action)(() =>
        {
            PSMessageBox mb = new PSMessageBox();
            mb._settings = settings;
            mb.lblTitle.Text = title;
            mb.lblCaption.Text = caption;
            mb.Buttons = buttons;
            result = mb.ShowDialog(owner);
        }));
        return result;
    }
