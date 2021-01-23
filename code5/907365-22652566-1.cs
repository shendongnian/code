    private void btnCustomizedToastPrompt_Click(object sender, RoutedEventArgs e)
    {
         SolidColorBrush gray = new SolidColorBrush(Colors.LightGray);
         SolidColorBrush orange = new SolidColorBrush(Color.FromArgb(200, 255, 117, 24));
          
        ToastPrompt toast = new ToastPrompt
        {
            Background = gray,
            Foreground = orange,
            Title = "Customized",
            Message = "Custom colors",
            FontSize = 30,
            TextOrientation = System.Windows.Controls.Orientation.Vertical,
            ImageSource =
                new BitmapImage(new Uri("ApplicationIcon.png", UriKind.RelativeOrAbsolute))
        };
     
        toast.Completed += toast_Completed;
        toast.Show();
    }
