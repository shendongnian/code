    private void ProcessAllControls(Control rootControl)
    {
        foreach (Control childControl in rootControl.Controls)
        {
             if(childControl is TextBox)
             {              
                  lblScope.Text += string.Format("<li>{0}</li>", (TextBox)childControl.Text);
             }
             else
             {     
                  ProcessAllControls(childControl);
             }   
        }
    }
