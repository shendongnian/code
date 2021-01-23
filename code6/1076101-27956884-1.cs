    public MyObject(MyEnum e)
    {
        switch(e) 
        {
            case MyEnum.ValueThatMeansWeDeserializeFromJSON:
                string text = System.IO.File.ReadAllText(fileName);
                var serializer = new JsonSerializer();
                serializer.Populate(new JsonTextReader(new StringReader(text)), this); // fixed
                break;
        }
    }
