    private void ShowToast(object sender, RoutedEventArgs e)
       {
           var toast = new ToastPrompt
           {
               Title = "The Title",
               Message = "A message",
               FontSize = 50,
               TextOrientation = System.Windows.Controls.Orientation.Vertical,
               ImageSource = new BitmapImage(new Uri("ApplicationIcon.png", UriKind.RelativeOrAbsolute))
           };
           toast.Show();
       }
