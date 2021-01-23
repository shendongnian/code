        public async Task<StorageFile> openFile()
        {
            Uri capitaleFileLoc = new Uri("ms-appx:///Assets/Capitale.txt");
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(capitaleFileLoc);//.AsTask().ConfigureAwait(false);
            return file;
        }
        public async Task<List<Pays>> splitFile(StorageFile file)
        {
           var list = await FileIO.ReadLinesAsync(file);//.AsTask().ConfigureAwait(false);
           List<Pays> listCountries = new List<Pays>();
           foreach (string country in list)
           {
               string[] countrycap = country.Split('\t');
               listCountries.Add(new Pays() { nomPays = countrycap[0], Capitale = countrycap[1] });
           }
           labelHighScore.Text =  listCountries[2].nomPays;
           return listCountries;
        }
