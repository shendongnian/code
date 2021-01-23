        private void SaveToIsolatedStorage(string filename)
        {
            // first, we grab the current apps isolated storage handle
            IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
            // we give our file a filename
            string strSaveName = filename;
            // if that file exists... 
            if (isf.FileExists(strSaveName))
            {
                // then delete it
                isf.DeleteFile(strSaveName);
            }
            // now we set up an isolated storage stream to point to store our data
            var isfStream = new IsolatedStorageFileStream(strSaveName, FileMode.Create, IsolatedStorageFile.GetUserStoreForApplication());
            isfStream.Write(stream.ToArray(), 0, stream.ToArray().Length);
            // ok, done with isolated storage... so close it
            isfStream.Close();
        }
