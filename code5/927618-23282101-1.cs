    // A date converter is necessary to handle the non-default date format
    IsoDateTimeConverter dateConverter = new IsoDateTimeConverter
    {
        DateTimeFormat = "dd/MM/yyyy"
    };
    // deserialize the JSON into a list of Item objects
    List<Item> items = 
        JsonConvert.DeserializeObject<List<Item>>(json, dateConverter);
    // find the max date among the items that is strictly less than today's date
    DateTime maxDate = 
        items.Where(i => i.EffectiveDate < DateTime.Today).Max(i => i.EffectiveDate);
    // with this max date in hand, filter the list to items matching that date
    List<Item> result = 
        items.Where(i => i.EffectiveDate == maxDate).ToList();
    // serialize the resulting list back to JSON
    string jsonResult =
        JsonConvert.SerializeObject(result, Formatting.Indented, dateConverter);
    // print out the new JSON (or whatever you need to do with it)
    Console.WriteLine(jsonResult);
