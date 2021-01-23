    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    
        public static class ExtensionMethods
        {
            /// <summary>
            /// Converts a DataTable to a strongly typed list
            /// </summary>
            /// <typeparam name="T">Generic object</typeparam>
            /// <param name="table">DataTable</param>
            /// <returns>List with generic objects</returns>
            public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
            {
                try
                {
                    List<T> list = new List<T>();
                    foreach (var row in table.AsEnumerable())
                    {
                        T obj = new T();
    
                        foreach (var prop in obj.GetType().GetProperties())
                        {
                            try
                            {
                                PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                                propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        list.Add(obj);
                    }
                    return list;
                }
                catch
                {
                    return null;
                }
            }
        }
