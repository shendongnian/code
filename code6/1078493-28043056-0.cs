            using (TableEntities db = new TableEntities())
            {
                var type = Type.GetType("namespace." + tableName);
                var query = db.Database.SqlQuery(type, "SELECT * FROM " + tableName);
                foreach (var row in query)
                {
                    PropertyInfo prop = type.GetProperty("NAME");
                    string name = (string)prop.GetValue(row);
                }
            }
