            private void SaveThumbnail()
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    var w = (int)_videoCaptureDevice.PreviewResolution.Width;
                    var h = (int)_videoCaptureDevice.PreviewResolution.Height;
    
                    var argbPx = new Int32[w * h];
    
                    _videoCaptureDevice.GetPreviewBufferArgb(argbPx);
                    var wb = new WriteableBitmap(w, h);
                    argbPx.CopyTo(wb.Pixels, 0);
                    wb.Invalidate();
    
                    using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        var fileName = _isoVideoFileName + ".jpg";
    
                        if (isoStore.FileExists(fileName))
                            isoStore.DeleteFile(fileName);
    
                        var file = isoStore.CreateFile(fileName);
                        wb.SaveJpeg(file, w, h, 0, 20);
                        file.Close();
                    }
                });
            }
