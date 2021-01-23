            Debug.WriteLine("TextureArray.FromFilesAsync() T1 : Thread Id = " + GetCurrentThreadId());
            List<StorageFile> files = new List<StorageFile>();
            foreach (string path in paths)
            {
                if (path != null)
                    files.Add(await Package.Current.InstalledLocation.GetFileAsync(path)); // << new threads
                else
                    files.Add(null);
            }
            Debug.WriteLine("TextureArray.FromFilesAsync() T2 : Thread Id = " + GetCurrentThreadId());
