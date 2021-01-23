        static Point ScrollPosition = new Point();
        private void MyWebView_ScriptNotify(object sender, NotifyEventArgs e)
        {
            string[] Coordinates = e.Value.Split(',');
            ScrollPosition.X = double.Parse(Coordinates[0]);
            ScrollPosition.Y = double.Parse(Coordinates[1]);
        }
        private async void MyWebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            await MyWebView.InvokeScriptAsync("SetScrollPosition", new string[] { ScrollPosition.X.ToString(), ScrollPosition.Y.ToString() });
        }
