        internal static void OnShowNewView(object sender, ShowCreatedWebViewEventArgs e)
        {
            WebControl webControl = sender as WebControl;
            if (webControl == null)
                return;
            if (!webControl.IsLive)
                return;
            ChildWindow newWindow = new ChildWindow();
            if (e.IsPopup && !e.IsUserSpecsOnly)
            {
                Int32Rect screenRect = e.Specs.InitialPosition.GetInt32Rect();
                newWindow.NativeView = e.NewViewInstance;
                newWindow.ShowInTaskbar = false;
                newWindow.WindowStyle = System.Windows.WindowStyle.ToolWindow;
                newWindow.ResizeMode = e.Specs.Resizable ? ResizeMode.CanResizeWithGrip : ResizeMode.NoResize;
                if ((screenRect.Width > 0) && (screenRect.Height > 0))
                {
                    newWindow.Width = screenRect.Width;
                    newWindow.Height = screenRect.Height;
                }
                newWindow.Show();
                if ((screenRect.Y > 0) && (screenRect.X > 0))
                {
                    newWindow.Top = screenRect.Y;
                    newWindow.Left = screenRect.X;
                }
            }
            else if (e.IsWindowOpen || e.IsPost)
            {
                newWindow.NativeView = e.NewViewInstance;
                newWindow.Show();
            }
            else
            {
                e.Cancel = true;
                newWindow.Source = e.TargetURL;
                newWindow.Show();
            }
        }
