     using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (IsolatedStorageFileStream imageStream = new IsolatedStorageFileStream("/Shared/ShellContent/" + imagename + ".png", System.IO.FileMode.Create, isf))
            {
                  Cimbalino.Phone.Toolkit.Extensions.WriteableBitmapExtensions.SavePng(b, imageStream);
                
            }
        }
