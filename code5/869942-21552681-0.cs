                String tempJPEG = "logo.jpg";
     
                // Create virtual store and file stream. Check for duplicate tempJPEG files.
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (myIsolatedStorage.FileExists(tempJPEG))
                    {
                        myIsolatedStorage.DeleteFile(tempJPEG);
                    }
     
                    IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile(tempJPEG);
     
                    StreamResourceInfo sri = null;
                    Uri uri = new Uri(tempJPEG, UriKind.Relative);
                    sri = Application.GetResourceStream(uri);
     
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.SetSource(sri.Stream);
                    WriteableBitmap wb = new WriteableBitmap(bitmap);
     
                    // Encode WriteableBitmap object to a JPEG stream.
                    Extensions.SaveJpeg(wb, fileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);
     
                    //wb.SaveJpeg(fileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);
                    fileStream.Close();
                }
