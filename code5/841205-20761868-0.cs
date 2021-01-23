    private void MainWindowCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        EnlargedScreenShot ess = new EnlargedScreenShot();
        if (e.Command == SelectImageCommand)
        {
            selectedImages.Add(e.Parameter as BitmapSource);
            ess.DataContext = selectedImages;
            this._contentPresenter2.Content = ess;
        }
    }
