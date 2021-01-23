    var contactImg = e.Results.Select(x => x.GetPicture()).FirstOrDefault();
                if (contactImg != null)
                {
                    BitmapImage bm = new BitmapImage();
                    bm.SetSource(contactImg);
                    imagelable.Source = bm;
                    MessageBox.Show(c.DisplayName);
                }
