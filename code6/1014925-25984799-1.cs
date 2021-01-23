        public static bool PasteImageFiles(this FlowDocument doc, TextRange selection, IEnumerable<string> files)
        {
            // Assuming you have one file that you care about, pass it off to whatever
            // handling code you have defined.
            FlowDocument tempDoc = new FlowDocument();
            Paragraph par = new Paragraph();
            tempDoc.Blocks.Add(par);
            foreach (var file in files)
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(file));
                    Image image = new Image();
                    image.Source = bitmap;
                    image.Stretch = Stretch.None;
                    InlineUIContainer container = new InlineUIContainer(image);
                    par.Inlines.Add(container);
                }
                catch (Exception)
                {
                    Debug.WriteLine("\"file\" was not an image");
                }
            }
            if (par.Inlines.Count < 1)
                return false;
            try
            {
                var imageRange = new TextRange(par.Inlines.FirstInline.ContentStart, par.Inlines.LastInline.ContentEnd);
                using (var ms = new MemoryStream())
                {
                    string format = DataFormats.XamlPackage;
                    imageRange.Save(ms, format, true);
                    ms.Seek(0, SeekOrigin.Begin);
                    selection.Load(ms, format);
                    return true;
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Not an image");
                return false;
            }
        }
    }
