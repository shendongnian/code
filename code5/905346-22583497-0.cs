    var keyFromConfiguration = System.Configuration.ConfigurationManager.AppSettings["x36_key1"];
    
    Keys key = (Keys) Enum.Parse(typeof(Keys), keyFromConfiguration);
    switch (key)
        {
            case Keys.D1:
                //something happens here
                break;
            case Keys.D2:
                //something happens here
                break;
            case Keys.D3:
                //something happens here
                break;
            case Keys.D4:
                //something happens here
                break;
            case Keys.D5:
                //something happens here
                break;
        }
