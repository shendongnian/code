     if (sEnable == "Disabled")
     {
    
        var controls = this.Controls.OfType<Control>().Where(x=>x is TextBox || x is ComboBox || x is DateTimePicker);
        foreach(var control in controls)
              control.Enabled = false;
     }
