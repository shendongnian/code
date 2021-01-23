        private void EventHandlers()
        {
            this.LocationChanged += Titlebar_LocationChanged;
            this.Loaded += Titlebar_Loaded;
            this.PreviewMouseLeftButtonDown += Titlebar_PreviewMouseLeftButtonDown;
            this.PreviewMouseLeftButtonUp += Titlebar_PreviewMouseLeftButtonUp;
            this.MouseDoubleClick += Titlebar_MouseDoubleClick;
        }
