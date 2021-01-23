    class MyObject {
         List<dynamic> booster { get; set; }
    }
    var result = JsonConvert.Deserialize<MyObject>(json);
	
    string value = result.booster[0];
	var jArray = result.booster[15] as JArray;
	var strings = jArray.Values<string>();
	foreach(var item in strings)
		Console.WriteLine(item); 
