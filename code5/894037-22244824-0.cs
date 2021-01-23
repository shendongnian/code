    private void client_DownloadImageCompleted(IAsyncResult asynchronousResult)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                { 
                        WebRequestState webRequestState = asynchronousResult.AsyncState as WebRequestState;
    
                        AdditionalDataObject file = webRequestState._object;
    
                        using (HttpWebResponse response = (HttpWebResponse)webRequestState.Request.EndGetResponse(asynchronousResult))
                        {
                            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
                            {
                                        using (Stream stream = response.GetResponseStream())
                                        {
                                            BitmapImage b = new BitmapImage();
                                            b.SetSource(stream);
                                            WriteableBitmap wb = new WriteableBitmap(b);
                                            using (var isoFileStream = isoStore.CreateFile(yourImageFolder + file.Name))
                                            {
                                                var width = wb.PixelWidth;
                                                var height = wb.PixelHeight;
                                                System.Windows.Media.Imaging.Extensions.SaveJpeg(wb, isoFileStream, width, height, 0, 100);
                                            }
                                        }
                            }
                     }
                  });
            }
