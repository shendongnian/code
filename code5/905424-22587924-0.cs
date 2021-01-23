    foreach(Control ctrl in myTextBoxContainer.Controls)
            { 
                if(ctrl is TextBox)
                {
                    TextBox textbx = ctrl as TextBox; 
                    if(textbx.ReadOnly == false)
                    {
                        textbx.ReadOnly = true; 
                    }
                }
            }    
     
