    int index = 1;    
    string text;
    
    foreach(Control control in Controls)
    {
        if(control.TabIndex == index)
        {
            text = control.Text;
            break;
        }
     }
            
