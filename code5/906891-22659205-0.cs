                //Setup a root content user control so we can swap out the content depending on what we want to show
            UserControl RootContent = new UserControl();
            RootContent.HorizontalAlignment = HorizontalAlignment.Stretch;
            RootContent.VerticalAlignment = VerticalAlignment.Stretch;
            DispatcherHelper.Initialize();
            this.RootVisual = RootContent;
            (this.RootVisual as UserControl).Content = new SplashScreenView();
