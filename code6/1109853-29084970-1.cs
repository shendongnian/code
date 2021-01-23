    DataTable dt = new DataTable();
    dt.Columns.Add("Field1", typeof(string));
    dt.Columns.Add("Field2", typeof(string));
    ...
    foreach (IHit<JObject> x in result.Hits)
    {
       dt.Rows.Add(
           x.Fields.FieldValuesDictionary["Prop1"] as JArray,
           x.Fields.FieldValuesDictionary["Prop2"] as JArray
           ...
       );
    }    
