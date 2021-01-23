    using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (myIsolatedStorage.FileExists("Shared/ShellContent/logo.png"))
                    {
                        return;
                    }
    
                    IsolatedStorageFileStream fileStream1 = myIsolatedStorage.CreateFile("Shared/ShellContent/logo.png");
    
                    Uri uri = new Uri("home.png", UriKind.Relative);
                    StreamResourceInfo sri = null;
                    sri = Application.GetResourceStream(uri);
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.SetSource(sri.Stream);
                    WriteableBitmap wb = new WriteableBitmap(bitmapImage);
                    
                    wb.WritePNG( fileStream1 as System.IO.Stream);
    
                    //wb.SaveJpeg(fileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);
                    
                    fileStream1.Close();
                }
