    foreach (String item in param.Parameter[lop].Component.Attributes.Items)
    {
        RadioButton radio = new RadioButton()
        {
            Content = item,
            GroupName = "MyRadioButtonGroup",
            Tag = //integer value from XML
        };
        radio.Checked += (o, e) =>
        {
            txtblkShowStatus.Text = item;       
        };
        data = param.Parameter[lop].Label;
        sp.Children.Add(radio);                           
    }
