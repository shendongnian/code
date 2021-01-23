    pnlUI.SuspendLayout();
    pnlUI.Controls.Clear();
    // if the previous content was set, add it back to the panel 
    if (_previousPanelContent != null)
    {
        pnlUI.Controls.Add(_previousPanelContent);
    }
    pnlUI.ResumeLayout(false);
