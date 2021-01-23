        private void EventHandlers()
        {
            this.LocationChanged += Titlebar_LocationChanged;
            this.Loaded += Titlebar_Loaded;
            this.MouseLeftButtonDown += Titlebar_PreviewMouseLeftButtonDown;
            this.PreviewMouseLeftButtonUp += Titlebar_PreviewMouseLeftButtonUp;
            this.MouseDoubleClick += Titlebar_MouseDoubleClick;
        }
