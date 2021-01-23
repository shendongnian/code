    ToastPrompt toast = new ToastPrompt();
    toast.Title = "Your app title";
    toast.Message = "Record saved.";
    toast.TextOrientation = Orientation.Horizontal;
    toast.MillisecondsUntilHidden = 2000;
    toast.ImageSource = new BitmapImage(new Uri("ApplicationIcon.png", UriKind.RelativeOrAbsolute));
     
    toast.Show();
