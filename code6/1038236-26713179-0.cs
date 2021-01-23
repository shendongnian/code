        private const string db_name = "store4.sqlite";
        SQLiteAsyncConnection connection = new SQLiteAsyncConnection(db_name);
        public async void InsertInspections(ObservableCollection<Inspections> inspections)
        {
            connection.CreateTableAsync<Inspections>().Wait();
            foreach (var inspection in inspections)
            {
                var task = connection.Table<Inspections>().
                    Where(v => v.InspectionId == inspection.InspectionId).ToListAsync();
                task.Wait();
                if (task.Result.Any())
                    connection.UpdateAsync(inspection);
                else
                    connection.InsertAsync(inspection);
            }
        }
