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
            return mb.ShowDialog();
            mb.ShowDialog(owner);
            result = DialogResult.OK;
        }));
        return result;
    }
