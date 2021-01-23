    private void Button_Click(object sender, RoutedEventArgs e)
    {
        NavigationPackage np = new NavigationPackage();
        np.TextToPass = textBox1.Text;
        np.ImgSource = bg2.Source;
    
        Frame.Navigate(typeof(MultiGame), np);
     }
