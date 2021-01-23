    private void EnabledPanelContents(Panel panel, bool enabled)
    {
    foreach (Control ctrl in panel.Controls)
    {
        ctrl.Enabled = true;
    }
    } 
