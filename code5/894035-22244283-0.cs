    public async Task<string> savePhotoLocal(BitmapImage photo, string photoName)
        {
           string folderName ="profilePictures";
           var profilePicture photoName+".jpg";        
           Stream outputStream = await profilePicture.OpenStreamForWriteAsync();
           if(outputStream!=null)
              {
               this.SaveImages(outputStream,folderName,profilePicture);
               }
           return profilePicture;
        }
    
    
    
    private void SaveImages(Stream data, string directoryName, string imageName)
            {
                try
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        data.CopyTo(memoryStream);
                        memoryStream.Position = 0;
                        byte[] buffer = null;
                        if (memoryStream != null && memoryStream.Length > 0)
                        {
                            BinaryReader binaryReader = new BinaryReader(memoryStream);
                            buffer = binaryReader.ReadBytes((int)memoryStream.Length);
                            Stream stream = new MemoryStream();
                            stream.Write(buffer, 0, buffer.Length);
                            stream.Seek(0, SeekOrigin.Begin);
                            string FilePath = System.IO.Path.Combine(directoryName, imageName);
                            IsolatedStorageFileStream isoFileStream = new IsolatedStorageFileStream(FilePath, FileMode.Create, StoreForApplication);
                            Deployment.Current.Dispatcher.BeginInvoke(() =>
                               {
                                   BitmapImage bitmapImage = new BitmapImage { CreateOptions = BitmapCreateOptions.None };
                                   bitmapImage.SetSource(stream);
                                   WriteableBitmap writeableBitmap = new WriteableBitmap(bitmapImage);
                                   writeableBitmap.SaveJpeg(isoFileStream, writeableBitmap.PixelWidth, writeableBitmap.PixelHeight, 0, 100);
                               });
                        }
                    }
    
                }
                catch (Exception ex)
                {
                    //ExceptionHelper.WriteLog(ex);
                }
            }
