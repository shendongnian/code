    public void LoadColors()
    {
        System.Windows.Media.SolidColorBrush red = new System.Windows.Media.SolidColorBrush();
        red.Color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00);
        System.Windows.Media.SolidColorBrush green = new System.Windows.Media.SolidColorBrush();
        green.Color = Color.FromArgb(0xFF, 0x00, 0xFF, 0x00);
        System.Windows.Media.SolidColorBrush blue = new System.Windows.Media.SolidColorBrush();
        blue.Color = Color.FromArgb(0xFF, 0x00, 0x00, 0xFF);
        this.PieChart.Brushes.Add(red);    // add red
        this.PieChart.Brushes.Add(green);  // add green
        this.PieChart.Brushes.Add(blue);   // add blue
        
        this.PieChart.DataSource = Data;   // set the datasource
    }
