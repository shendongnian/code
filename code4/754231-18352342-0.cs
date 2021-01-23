       BitmapImage image = new BitmapImage(new Uri(contact.PreviewPhoto));
                                image.ImageFailed += (s, e) =>
                                {
                                    image = new BitmapImage(new Uri("/no-picture.png", UriKind.Relative));
                                    a.photo.Source = image;
                                };
