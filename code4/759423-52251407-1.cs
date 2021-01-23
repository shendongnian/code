    [Test]
    public void ReaderTest()
    {
    	using (var conn = new SqlConnection(ConnectionSettingsCollection.Default))
    	{
    	    conn.Open();
    		const string sql = @"
    			SELECT 1 as OriginalField
    			UNION
    			SELECT -500 as OriginalField
    			UNION
    			SELECT 100 as OriginalField
    		";
    
    		var additionalFields = new[]
    		{
    			new WrappedDataReader.AdditionalField("StaticField", typeof(int), delegate { return "X"; }),
    			new WrappedDataReader.AdditionalField("CounterField", typeof(int), (i, reader) => i),
    			new WrappedDataReader.AdditionalField("ComputedField", typeof(int), (i, reader) => (int) reader["OriginalField"] + 1000)
    		};
    
    		const string expectedJson = @"
    			[
    				{""OriginalField"":-500,""StaticField"":""X"",""CounterField"":0,""ComputedField"":500},
    				{""OriginalField"":1,	""StaticField"":""X"",""CounterField"":1,""ComputedField"":1001},
    				{""OriginalField"":100,	""StaticField"":""X"",""CounterField"":2,""ComputedField"":1100}
    			]
    		";
    
    		var actualJson = ToJson(new WrappedDataReader(new SqlCommand(sql, conn).ExecuteReader(), additionalFields));
    
    		Assert.Zero(CultureInfo.InvariantCulture.CompareInfo.Compare(expectedJson, actualJson, CompareOptions.IgnoreSymbols));
    	}
    }
    private static string ToJson(IDataReader reader)
    {
    	using (var strWriter = new StringWriter(new StringBuilder()))
    	using (var jsonWriter = new JsonTextWriter(strWriter))
    	{
    		jsonWriter.WriteStartArray();
    
    		while (reader.Read())
    		{
    			jsonWriter.WriteStartObject();
    
    			for (var i = 0; i < reader.FieldCount; i++)
    			{
    				jsonWriter.WritePropertyName(reader.GetName(i));
    				jsonWriter.WriteValue(reader[i]);
    			}
    
    			jsonWriter.WriteEndObject();
    		}
    
    		jsonWriter.WriteEndArray();
    
    		return strWriter.ToString();
    	}
    }
