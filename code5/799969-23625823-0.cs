    private void Image_MouseLeftButtonDown(object sender,     System.Windows.Input.MouseButtonEventArgs e)
    {
      snare.Source= new Uri("snare.mp3, UriKind.Relative");
      snare.Play();
    }
