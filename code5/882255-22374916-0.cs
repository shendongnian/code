    if (testapp.linkvalue != "NULL")
    {
        var v = new ModernDialog
        {
            Title = "my test",
            Content = "pewpew lazers rule. If you agree click ok"
        };
    v.OkButton.Click += new RoutedEventHandler(OkButton_Click);
        v.Buttons = new Button[] { v.OkButton, v.CancelButton };
        var r = v.ShowDialog();
        
    }
    
    //And Then Create OkButtonClick
    
    private void OkButton_Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("ok was clicked");
            }
