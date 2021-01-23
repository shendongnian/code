    public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
    
        }
    public List<int> GetMostAndLeastBought(int howMany){
    List<Purchase> purchasesList = new List<Purchase>{
    		 									new Purchase{ id = 1, time = DateTime.UtcNow.Add(new TimeSpan(0, 0, -1)), quantity = 1},
    											new Purchase{id = 1, time = DateTime.UtcNow.Add(new TimeSpan(0, 0, -1)), quantity = 1},
    											new Purchase{id = 2, time = DateTime.UtcNow.Add(new TimeSpan(0, 0, -1)), quantity = 1},
    											new Purchase{id = 2, time = DateTime.UtcNow.Add(new TimeSpan(0, 0, -1)), quantity = 1},
    											new Purchase{id = 3, time = DateTime.UtcNow.Add(new TimeSpan(0, 0, -1)), quantity = 1},
    											new Purchase{id = 3, time = DateTime.UtcNow.Add(new TimeSpan(0, 0, -1)), quantity = 1},
    											new Purchase{id = 4, time = DateTime.UtcNow.Add(new TimeSpan(0, 0, -1)), quantity = 1},
    											new Purchase{id = 4, time = DateTime.UtcNow.Add(new TimeSpan(0, 0, -1)), quantity = 1},
    											new Purchase{id = 5, time = DateTime.UtcNow.Add(new TimeSpan(0, 0, -1)), quantity = 1},
    											new Purchase{id = 6, time = DateTime.UtcNow.Add(new TimeSpan(0, 0, -1)), quantity = 1},
    											new Purchase{id = 7, time = DateTime.UtcNow.Add(new TimeSpan(0, 0, -1)), quantity = 1}																				
    										};
    										
    		DataTable purchases = ConvertToDataTable(purchasesList);
