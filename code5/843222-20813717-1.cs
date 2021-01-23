    private void AddControlToPanel(Panel panel, Control ctrl)
    {
        if (panel.InvokeRequired)
        {
           panel.Invoke(new AddControlToPanelDlgt(AddControlToPanel), new object[] { panel, ctrl });          
        }
        else
            panel.Controls.Add(ctrl); //<-- here is where the exception is raised
    }
