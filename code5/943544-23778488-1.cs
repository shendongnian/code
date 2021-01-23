    if (fwPanel != null)
    {
        List<Control> listControls = fwPanel.Controls.Cast<Control>().ToList();
        foreach (Control control in listControls)
        {
            fwPanel.Controls.Remove(control);
            control.Dispose();
        }
        listOfFile.Clear();
    }
