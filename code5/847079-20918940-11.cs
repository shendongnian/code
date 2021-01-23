    System.Runtime.Serialization.Json.DataContractJsonSerializer ser = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(List<MyTable>));
	string table_json = e.Result.ToString();
    List<MyTable> result;
    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(table_json)))
    {
        result = (List<MyTable>)ser.ReadObject(ms);
    }
