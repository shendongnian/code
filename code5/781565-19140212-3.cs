	Dictionary<String, String> MyDtoDictionary = new Dictionary<String, String>();
	MyDtoDictionary.Add("Test1", "7");
	MyDtoDictionary.Add("Test2", "Value2");
	NullablePartials result = MyDtoDictionary.ToJson().FromJson<NullablePartials>();
	System.Diagnostics.Debug.WriteLine(MyDtoDictionary.ToJson());
	System.Diagnostics.Debug.WriteLine(result.ToJson());
	
