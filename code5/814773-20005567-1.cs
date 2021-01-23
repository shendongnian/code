    foreach(Control control in form.Controls)
    {
        if( control is Panel )
        {
           control.Visible = false;
           if(control.Name == "PanelName")
               control.Visible = true;
        }
    }
          
