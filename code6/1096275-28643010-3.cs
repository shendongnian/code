    foreach (Control c in DragPanel.Controls)   
    {
        if (c.GetType().Name == "TextBox")     
        {
              label1.Text += Environment.NewLine + ((TextBox)c).Text;     
        }
    }
