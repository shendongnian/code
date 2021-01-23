     ViewportControl llsViewPort;
        private void ViewPortLoaded(object sender, RoutedEventArgs e)
        {
            llsViewPort = sender as ViewportControl;
        }
     private void ScrollToBottom()
        {
            if (llsViewPort != null)
                llsViewPort.SetViewportOrigin(new System.Windows.Point(0, llsViewPort.Bounds.Height));
        }
