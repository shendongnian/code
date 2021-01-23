    public IEnumerable<Scene> GetScenes()
    {
        using (var filesystem = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (var fs = new IsolatedStorageFileStream("Scenes", FileMode.Open, filesystem))
            {
                var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(IEnumerable<Scene>));
                return serializer.ReadObject(fs) as IEnumerable<Scene>;
            }
        }
    }
