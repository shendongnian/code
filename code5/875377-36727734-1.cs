     public async void loadData() {
            ObservableCollection<string> n = new ObservableCollection<string>();
            StorageFile sf = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(@"Assets\Data.txt");
            var data = await FileIO.ReadTextAsync(sf);
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<myData>));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));
            List<myData> nm = (List<myData>)json.ReadObject(ms);
            foreach (var item in nm)
            {
                n.Add(item.Name);
            }
            names.DataContext = n;
            
        }
