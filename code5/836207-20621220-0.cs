        public static async Task<IList<Person>> GetPeople()
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/People.xml"));
            var stream = await file.OpenStreamForReadAsync();
            using (StreamReader sr = new StreamReader(stream))
            {
                while (sr.Peek() >= 0)
                {
                    var a = sr.ReadLine();
                }
            }
         }
