    var tb = new TextBox();
    var box = new CustomMessageBox()
    {
        Caption = "File name",
        Message = "Please enter a file name",
        LeftButtonContent = AppResources.Ok,
        RightButtonContent = AppResources.Cancel,
        Content = tb,
        IsFullScreen = false
    };
    box.Dismissed += (s, e) =>
    {
        if( e.Result == CustomMessageBoxResult.LeftButton )
        {
            var filename = tb.Text;
            // User clicked OK, go ahead and save
        }
    };
    box.Show();
