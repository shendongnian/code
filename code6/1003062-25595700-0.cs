        private void SaveAndReloadButton_Click(object sender, RoutedEventArgs e)
        {
            var range = new TextRange(this.RichText.Document.ContentStart, this.RichText.Document.ContentEnd);
            using (var memoryStream = new MemoryStream())
            {
                range.Save(memoryStream, DataFormats.XamlPackage);
                memoryStream.Position = 0;
                // load
                range = new TextRange(this.RichText.Document.ContentStart, this.RichText.Document.ContentEnd);
                range.Load(memoryStream, DataFormats.XamlPackage);
            }
        }
