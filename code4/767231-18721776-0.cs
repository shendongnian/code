    JsonSerializer ser = new JsonSerializer();
    ser.Converters.Add(new DummyConverter<TempClass>(t =>
        {
           //A callback method
            Console.WriteLine(t.text);
        }));
    ser.Deserialize(new JsonTextReader(new StreamReader(File.OpenRead(fName))), 
                    typeof(List<TempClass>));
