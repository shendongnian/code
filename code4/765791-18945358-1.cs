        public static void WriteBackgroundSetting(string currentBackground)
        {
            const string fileName = "RecipeHub.txt";
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if(myIsolatedStorage.FileExists(fileName))
                    myIsolatedStorage.DeleteFile(fileName);
                var stream = myIsolatedStorage.CreateFile(fileName);
                using (StreamWriter isoStream = new StreamWriter(stream))
                {
                    isoStream.WriteLine(currentBackground);
                }
            }
        }
