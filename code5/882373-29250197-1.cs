    RootFrame.Navigating += (s, e) =>
            {
                AppUriMapper.IsNavigating = true;
                System.Diagnostics.Debug.WriteLine("goto: [mode] {0}, [uri] {1}", e.NavigationMode, e.Uri);
            };
