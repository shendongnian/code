        public void GridMethod()
        {
            ModelCollection = new ObservableCollection<SchoolModel>();
            ModelCollection.Add(new SchoolModel() {Id=1, Name="ABC" });
            ModelCollection.Add(new SchoolModel() { Id = 2, Name = "PQR" });
            ModelCollection.Add(new SchoolModel() { Id = 3, Name = "DEF" });
            OnPropertyChanged("ModelCollection");
        }
