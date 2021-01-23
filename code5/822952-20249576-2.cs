    public class DBConnection
    {
        public static ObservableCollection<T> GetDataOutDatabase<T>(string table)
        {
            var objecten = new ObservableCollection<T>();
            string sql = "SELECT * FROM " + table;
            DbDataReader reader = Database.GetData(sql);
            
            while (reader.Read())
            {
                objecten.Add(Create<T>(reader));
            }
            return objecten;
        }
        public static T Create<T>(IDataRecord record)
        {
            var properties = typeof(T).GetProperties();
            var returnVal = Activator.CreateInstance(typeof(T));
            properties.ToList().ForEach(item =>
                {
                    try
                    {
                        if (item.PropertyType.IsPrimitive)
                        {
                            item.SetValue(returnVal, Convert.ChangeType(record[item.Name].ToString(), item.PropertyType),null);
                        }
                        else
                        {
                            object[] parameters = {record};
                            var value =
                            typeof(DBConnection).GetMethod("Create").MakeGenericMethod(item.PropertyType).Invoke(null, parameters);
                            item.SetValue(returnVal,value,null);
                        }
                    }
                    catch
                    {
                        Write("Property Not Found");
                    }
                });
            return (T)returnVal;
        }
    }
