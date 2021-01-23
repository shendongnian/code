    public void method2(string naziv)
    {
        MessageBox.Show("test? "+naziv); //only for test. This works
        Button x = new Button();
        x.Margin = new Thickness(50, 20, 0, 0);
        x.VerticalAlignment = VerticalAlignment.Top;
        x.HorizontalAlignment = HorizontalAlignment.Left;
        x.Height = 50;
        x.Width = 100;
        x.FontSize = 20;
        x.Content = naziv;
        x.Name = "naziv";
        gridmiza.Children.Add(x);
        lbltest1.Content = "test? "+naziv; //only for test
        MessageBox.Show("test2?"); //only for test and this also works works
    }
