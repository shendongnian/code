    // or some other method of accessing the current page
    // - but via Application, to which you have access also in class library
    var currentPage = (PhoneApplicationPage)((PhoneApplicationFrame)Application.Current.RootVisual).Content;
    currentPage.BackKeyPress += (sender, args) =>
        {
            // Display dialog or something, and when you decide not to perform back navigation:
            args.Cancel = true;
        };
