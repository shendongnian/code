        private void Unzip()
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                ZipEntry entry;
                int size;
                byte[] data = new byte[2048];
                using (ZipInputStream zip = new ZipInputStream(store.OpenFile("YourZipFile.zip", FileMode.Open)))
                {
                    // retrieve each file/folder
                    while ((entry = zip.GetNextEntry()) != null)
                    {
                        if (!entry.IsFile)
                            continue;
                         
                        // if file name is music/rock/new.mp3, we need only new.mp3
                        // also you must make sure file name doesn't have unsupported chars like /,\,etc.
                        int index = entry.Name.LastIndexOf('/');
                        string name = entry.Name.Substring(index + 1);
                        // create file in isolated storage
                        using (var writer = store.OpenFile(name, FileMode.Create))
                        {
                            while (true)
                            {
                                size = zip.Read(data, 0, data.Length);
                                if (size > 0)
                                    writer.Write(data, 0, size);
                                else
                                    break;
                            }
                        }
                    }
                }
            }
        }
