    public void SaveScenes(IEnumerable<Scene> scenes)
    {
        using (var filesystem = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (var fs = new IsolatedStorageFileStream("Scenes", FileMode.Create, filesystem))
            {
                var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(IEnumerable<Scene>));
                serializer.WriteObject(fs, Scenes);
            }
        }
    }
