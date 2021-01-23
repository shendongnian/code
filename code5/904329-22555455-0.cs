        MediaElement Test= new MediaElement();
        Test.Source = new Uri ("/Assets/Sounds/press.mp3",UriKind.Relative);
        Test.Position = TimeSpan.Zero;
        Test.Volume = 1;
        Test.AutoPlay = false;
        LayoutRoot.Children.Add(Test);
        Test.Play();
