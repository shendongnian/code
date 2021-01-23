    var testingobject = // file read lines here...
    var car_collection =
        from line in testingobject.ToList().Skip(0)
        let parts = line.Split(',')
        select new CarClass()
        {
            Id = Int32.Parse(parts[0]),
            Engine = parts[1],
            Car = Int32.Parse(parts[2])
        };
    var listy = car_collection.ToList();
