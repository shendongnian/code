            using (var db = new Entities.YourEntities())
            {
                var originalObj = db.MyTable.FirstOrDefault();
                foreach (var prop in originalObj.GetType().GetProperties())
                {
                    var type = prop.PropertyType;
                    if (type.Namespace != "System")
                        continue;
                    var name = prop.Name;
                    var value = prop.GetValue(originalObj, null);
                    //your code here
                }
            }
