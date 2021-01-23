    var xCar = xDoc.Root.Descendants()
        .FirstOrDefault(d => d.Name.LocalName.Equals("car"));
    var serializer = new XmlSerializer(typeof(Automobile));
    using (var reader = xCar.CreateReader())
    {
        var result = (Automobile)serializer.Deserialize(reader);
        Console.WriteLine(result.Make);
        Console.WriteLine(result.Model);
    }
