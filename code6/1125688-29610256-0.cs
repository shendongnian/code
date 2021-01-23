    var pdfimage = new Image();
    BitmapImage src = new BitmapImage();
    src.BeginInit();
    src.UriSource = new Uri(@"pack://application:,,,/DocumentHandlingTouch;component/Resources/pdf.jpg", UriKind.Absolute); 
    src.EndInit();
    pdfimage.Source = src;
