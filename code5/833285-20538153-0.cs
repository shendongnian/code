            using (IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForApplication())
            {
                //To read
                using (StreamReader r = new StreamReader(f.OpenFile("settings.txt", FileMode.OpenOrCreate)))
                {
                    string text = r.ReadToEnd();
                }
                //To write
                using (StreamWriter w = new StreamWriter(f.OpenFile("settings.txt", FileMode.Create)))
                {
                    w.Write("Hello World");
                }
            }
