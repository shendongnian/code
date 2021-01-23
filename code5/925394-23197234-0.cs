    /// <summary>
            /// Persists the object on HD
            /// </summary>
            public static void PersistObject()
            {
                Logger.Debug("PersistObject: Started");
                // Persist to file
                FileStream stream = File.OpenWrite(_filePath);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, objectToSave);
                stream.Close();
    
                Logger.Debug("PersistObject: Ended");
            }
    
      /// <summary>
            /// Loads the object.
            /// </summary>
            public static void LoadObject()
            {
                try
                {
                    Logger.Debug("LoadObject: Started");
                    //Open file to read saved DailyUsers object
                    if (File.Exists(_filePath))
                    {
                        FileStream stream = File.OpenRead(_filePath);
                        BinaryFormatter formatter = new BinaryFormatter();
    
                        object deserializedObject = formatter.Deserialize(stream);
                        stream.Close();
                    }
                    Logger.Debug("LoadObject: Ended");
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, ex.Message);
                }
            }
