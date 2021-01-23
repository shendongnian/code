    private void UpdateLabel()
    {
        label1.Text = "";
        foreach (Control c in DragPanel.Controls)   //Going through all controls in the panel
        {
            if (c.GetType().Name == "Button")        // Checking whether the control is a Button
                label1.Text += Environment.NewLine+ ((Button)c).Text;     //Updating the label
        }
    }
