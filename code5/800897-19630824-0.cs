        public static List<T> DataTableToEntities<T>(DataTable dt)
        {
            string propName = string.Empty;
            List<T> entityList = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {                
                T entity = System.Activator.CreateInstance<T>();
                System.Reflection.PropertyInfo[] entityProperties = typeof(T).GetProperties();
                foreach (System.Reflection.PropertyInfo item in  entityProperties)
                {
                    propName = item.Name;
                    
                    if (dt.Columns.Contains(propName))
                    {                  
                        item.SetValue
                        (
                            entity,
                            dr[propName].GetType().Name.Equals(typeof(DBNull).Name)? null : dr[propName],
                            null
                        );
                    }
                }
                entityList.Add(entity);
            }
            return entityList;
        }
