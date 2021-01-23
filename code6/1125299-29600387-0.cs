    public async void Attach(DependencyObject associatedObject)
        {
            AssociatedObject = associatedObject;
            var frame = Window.Current.Content as Frame;
            while (frame.Content == null)
                await Task.Delay(100);
            var page = frame.Content as Page;
            var panel = page.Content as Panel;
             Initialize();
      }
