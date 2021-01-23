    string s = "Foo Bar Baz Quux";
    Data data = new Data
    {
        Bytes = Encoding.UTF8.GetBytes(s)
    };
    string json = JsonConvert.SerializeObject(data);
    Console.WriteLine(json);
    data = JsonConvert.DeserializeObject<Data>(json);
    Console.WriteLine(Encoding.UTF8.GetString(data.Bytes));
