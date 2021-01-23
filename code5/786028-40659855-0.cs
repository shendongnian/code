                System.Windows.Documents.FixedPage fixedPage = new System.Windows.Documents.FixedPage();
                System.Windows.Documents.PageContent pageContent = new System.Windows.Documents.PageContent();
                pageContent.Child = fixedPage;
                if (fixedDocument == null)
                {
                    fixedDocument = new System.Windows.Documents.FixedDocument();
                }
                fixedDocument.Pages.Add(pageContent);
                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                TiffBitmapDecoder decoder = new TiffBitmapDecoder(new Uri(tiffImage, UriKind.Relative), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnDemand);
                image.Source = decoder.Frames[0];
                fixedPage.Children.Add(image);
                //Code to make the legal letter size work.
                Size sz = new Size(decoder.Frames[0].Width, decoder.Frames[0].Height);
                fixedPage.Width = sz.Width;
                fixedPage.Height = sz.Height;
                pageContent.Width = sz.Width;
                pageContent.Height = sz.Height;
