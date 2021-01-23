        public class Test
        {
            // function that set the given object from the given data row
            public static void SetItemFromRow<T>(T item, DataRow row) where T : new()
            {
                foreach (DataColumn c in row.Table.Columns)
                {
                    PropertyInfo prop = item.GetType().GetProperty(c.ColumnName);
    
                    if (prop != null && row[c] != DBNull.Value)
                    {
                        prop.SetValue(item, row[c], null);
                    }
                    else
                    {
                        if (c.ColumnName == "CityID")
                        {
                            object obj = Activator.CreateInstance(typeof(City));
                            
                            SetItemFromRow<City>(obj as City, row.GetChildRows("ClientsToCity")[0]);
                            PropertyInfo nestedprop = item.GetType().GetProperty("ClientCity");
                            nestedprop.SetValue(item, obj, null);
                        }
                        else if (c.ColumnName == "CountryID")
                        {
                            object obj = Activator.CreateInstance(typeof(Country));
                            
                            SetItemFromRow<Country>(obj as Country, row.GetChildRows("CityToCountry")[0]);
                            PropertyInfo nestedprop = item.GetType().GetProperty("CityCountry");
                            nestedprop.SetValue(item, obj, null);
                        }
                    }
    
                }
            }
    
            // function that creates an object from the given data row
            public static T CreateItemFromRow<T>(DataRow row) where T : new()
            {
                T item = new T();
    
                SetItemFromRow(item, row);
    
                return item;
            }
    
            // function that creates a list of an object from the given data table
            public static List<T> CreateListFromTable<T>(DataTable tbl) where T : new()
            {
                List<T> lst = new List<T>();
    
                foreach (DataRow r in tbl.Rows)
                {
                    lst.Add(CreateItemFromRow<T>(r));
                }
    
                return lst;
            }
        }
