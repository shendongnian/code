    // ----------------------------------------------------------------
                // Write the friend name to the locations text file upon submission
                // ----------------------------------------------------------------
    
                StringBuilder sb = new StringBuilder();                                 // Use a StringBuilder to construct output.
                var store = IsolatedStorageFile.GetUserStoreForApplication();           // Create a store
                string[] filesInTheRoot = store.GetFileNames();                         // Store all files names in an array
                Debug.WriteLine(filesInTheRoot[0]);                                     // Show first file name retrieved (only one stored at the moment)
                byte[] data = Encoding.UTF8.GetBytes(locationName + ";");
                string filePath = "locations.txt";
    
                if (store.FileExists(filePath))
                {
                    using (var stream = new IsolatedStorageFileStream(filePath, FileMode.Append, store))
                    {
    
                        Debug.WriteLine("Writing...");
                        stream.Write(data, 0, data.Length);   // Semi Colon required for location separation in text file
                        stream.Close();
                        Debug.WriteLine(locationName + "; added");
                        Debug.WriteLine("Writing complete");
                    }
    
    
                }
