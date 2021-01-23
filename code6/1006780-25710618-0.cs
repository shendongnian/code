    private void RegUser()
    {
        this.Dispatcher.Invoke((Action)(() =>
        {
            ImgLoading.Visibility = Visibility.Visible;
        }));
        //method body
        .....           
        this.Dispatcher.Invoke((Action)(() =>
        {
            ImgLoading.Visibility = Visibility.Hidden;
        }));
    }
