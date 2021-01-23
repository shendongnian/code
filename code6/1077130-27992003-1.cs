    private void ProcessAllControls(Control rootControl)
    {
        foreach (Control childControl in rootControl.Controls)
        {
             if(childControl is TextBox)
             {  
                  TextBox txt = (TextBox)childControl;             
                  lblScope.Text += string.Format("<li>{0}</li>", txt.Text);
             }
             else
             {     
                  ProcessAllControls(childControl);
             }   
        }
    }
