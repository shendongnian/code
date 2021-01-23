      public static void SaveFile(String FileName, List<String> File)
        {
            try
            {
                if (FileName.Length < 1)
                {
                    throw new System.ArgumentException("File Name Must Not Be Empty");
                }
                if (IsolatedStorageFile.GetUserStoreForApplication().AvailableFreeSpace <= 0)
                {
                    throw new System.ArgumentException("Isolated Storage Out of Memory - Please free up space.");
                }
                if (IsolatedStorageFile.GetUserStoreForApplication().FileExists(FileName))
                {
                    throw new System.ArgumentException("File Already Exists - Please choose a unique name.");
                }
                if (File == null)
                {
                    throw new System.ArgumentException("Cannot Save Null Files");
                }
            }
            catch (Exception e)
            {
                return;
            }
            try
            {
                SerializableObject so = new SerializableObject() { serFile = File };
                DataContractSerializer dsc = new DataContractSerializer(so.GetType());
    
                IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
                StreamWriter writer;
    
                writer = new StreamWriter(new IsolatedStorageFileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, file));
    
                dsc.WriteObject(writer.BaseStream, so);
            }
            catch (Exception error) { throw new System.ArgumentException(error.Message); }
    
        }
