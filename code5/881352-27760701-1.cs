    public static DataTable JsonToDataTable(string json, string tableName)
    {
        bool columnsCreated = false;
        DataTable dt = new DataTable(tableName);
        Newtonsoft.Json.Linq.JObject root = Newtonsoft.Json.Linq.JObject.Parse(json);
        Newtonsoft.Json.Linq.JArray items = (Newtonsoft.Json.Linq.JArray)root[tableName];
        Newtonsoft.Json.Linq.JObject item = default(Newtonsoft.Json.Linq.JObject);
        Newtonsoft.Json.Linq.JToken jtoken = default(Newtonsoft.Json.Linq.JToken);
        for (int i = 0; i <= items.Count - 1; i++)
        {
            // Create the columns once
            if (columnsCreated == false)
            {
                item = (Newtonsoft.Json.Linq.JObject)items[i];
                jtoken = item.First;
                while (jtoken != null)
                {
                    dt.Columns.Add(new DataColumn(((Newtonsoft.Json.Linq.JProperty)jtoken).Name.ToString()));
                    jtoken = jtoken.Next;
                }
                columnsCreated = true;
            }
            // Add each of the columns into a new row then put that new row into the DataTable
            item = (Newtonsoft.Json.Linq.JObject)items[i];
            jtoken = item.First;
            // Create the new row, put the values into the columns then add the row to the DataTable
            DataRow dr = dt.NewRow();
            while (jtoken != null)
            {
                dr[((Newtonsoft.Json.Linq.JProperty)jtoken).Name.ToString()] = ((Newtonsoft.Json.Linq.JProperty)jtoken).Value.ToString();
                jtoken = jtoken.Next;
            }
            dt.Rows.Add(dr);
        }
        return dt;
    }
