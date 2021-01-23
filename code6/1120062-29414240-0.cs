    private void TabControl1_Selecting(Object sender, TabControlCancelEventArgs e) 
    {
    
        TextBox dynamictextbox = new TextBox();
        dynamictextbox.Text = "(Enter some text)";
        dynamictextbox.ID = "dynamictextbox";
        (TabControl)sender.controls.Add(dynamictextbox)
    }
    
    }
