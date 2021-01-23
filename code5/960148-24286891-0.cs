    foreach (String item in param.Component.Attributes[0].Item)
    {
         RadioButton radio = new RadioButton()
        {
            Content = item,
            GroupName = "MyRadioButtonGroup",
           // Name = "param_"+param.Name
        };
        radio.Checked += (o, e) =>
        {
            txtblkShowStatus.Text = item;             
        };
        radio.IsEnabled = false;
        sp.Children.Add(radio);
        count++;     
    }
    
