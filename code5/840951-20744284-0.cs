    int t = 0;
    private void btnAddTitle_Click(object sender, RoutedEventArgs e)
    {
        //a new stackpanel is used to arrange items Horizontally for each line
        StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
        TextBox x = new TextBox();
        x.Name = "Title" + t;
        x.Text = "Title...";
        x.FontWeight = FontWeights.Bold;
        x.FontStyle = FontStyles.Italic;
        x.TextWrapping = TextWrapping.Wrap;
        x.Height = 25;
        x.Width = 200;
        x.Margin = new Thickness(0, 15, 0, 0);
        ComboBox y = new ComboBox();
        y.Name = "Combo" + t;
        y.Text = (t + 1).ToString();
        y.Height = 25;
        y.Width = 45;
        y.Margin = new Thickness(0, 15, 0, 0);
        sp.Children.Add(y);
        sp.Children.Add(x);        
        spStandard.Children.Add(sp);
        t++;
    }
