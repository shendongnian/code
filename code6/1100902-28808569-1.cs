        private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            var hl = e.OriginalSource as System.Windows.Documents.Hyperlink;
            Process.Start(hl.NavigateUri.AbsoluteUri);
        }
