    var properties = new Dictionary<string, object>
    {
        {"Name", "Bart"},
        {"Date", new DateTime(2014,9,23)},
        {"Age", 300}
    }
    var item = HelperClass.Populate(properies)
    Console.WriteLine(item.Name); // should print "bart"
