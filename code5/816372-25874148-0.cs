            // If we want main to stay on top, we set the rest of the menus to Not be top 
            if (mnuViewMainWindowAlwaysOnTopo.IsChecked)
            {
                this.Topmost = true;
                foreach (Window window in Application.Current.Windows)
                {
                    // Don't change for main window
                    if (window.GetType().Name != this.GetType().Name)
                    {
                        window.Topmost = false;
                    }
                }
            }
            else
            {
                this.Topmost = false;
            }
