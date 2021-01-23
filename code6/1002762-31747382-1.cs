    string tableName = typeof(Customer).Name;
    var customAttributes = typeof(Customer).GetCustomAttributes(typeof(SQLite.Net.Attributes.TableAttribute),false);
    if (customAttributes.Count() > 0)
    {
        tableName = (customAttributes.First() as SQLite.Net.Attributes.TableAttribute).Name;
    }
    var info = database.Connection.GetTableInfo(tableName);
    if (!info.Any())
    {
       //do stuff
    }
