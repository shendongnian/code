    {
        radio = new RadioButton()
        {
            Content = item,
            GroupName = "MyRadioButtonGroup",
           // Name = "param_"+param.Name
        };
        radio.Checked += (o, e) =>
        {
            txtblkShowStatus.Text = item;             
        };
        sp.Children.Add(radio);
        radio.IsEnabled = false;
    
        count++;                
    }
