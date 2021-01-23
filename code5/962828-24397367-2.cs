       foreach (String item in param.Component.Attributes[0].Item)
                {
                    radio = new RadioButton()
                    {
                        Content = item,
                        GroupName = "MyRadioButtonGroup",
                        Tag = tg
    
                    };
     radio.Checked += (o, e) =>
                    {
                        //Do  something                
                    };
    
                    sp.Children.Add(radio);
                    count++; tg++;   
                    if (count == 2){
                    radio.IsChecked=true;
                    }
                }
