    private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            var radioFired = (RadioButton)sender;
            Check(radioFired.Name);
        }
    
        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            var radioFired = (RadioButton)sender;
            Check(radioFired.Name);
        }
    
    public void Check(string radioName)
        {
            switch(radioName)
            {
                case "radio1a":
                   n1 = answer1;
                   break;
                case "radio1b":
                    n1 = answer2;
                    break;
                etc...
             }
        }
