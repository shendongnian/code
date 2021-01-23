    dynamic items = JsonConvert.DeserializeObject(jsonString);
    var list = new List<SampleObject>();
    foreach (var item in items)
    { 
        var sampleObject = new SampleObject
                               {
                                   Letter = item[0].ToString(),
                                   FirstNumber = item[1].ToString(),
                                   SecondNumber = item[2].ToString()
                               }
        list.Add(sampleObject);        
    }
