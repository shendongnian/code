    Task.Factory.StartNew(() =>
                    {
                        var result = GetImage();
                        var bitmap = new BitmapImage();
                        var stream = result;    
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.StreamSource = stream;
                            
                        bitmap.EndInit();
                        bitmap.Freeze();
                        stream.Dispose();
                        disp.Invoke(new Action(()=> MyImage.Source = bitmap));
                    });
