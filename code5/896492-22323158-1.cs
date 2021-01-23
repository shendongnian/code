    private bool CanCurrentViewClose()
    {
        if (groupBox1.Controls.Count == 0)
            return true;
        IView v = groupBox1.Controls[0] as IView;
        return v.CanClose();
    }
    private void SwitchView(IView newView)
    {
        if (groupBox1.Controls.Count > 0)
        {
            UserControl oldView = groupBox1.Controls[0] as UserControl;
            groupBox1.Controls.Remove(oldView);
            oldView.Dispose();
        }
        groupBox1.Controls.Add(newView);
        newView.Dock = Dock.Fill;
    }
            
