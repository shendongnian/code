    foreach(var cls1 in listObj1.Where(c1=> c1.PropertyA > 5 && c1.PropertyB > 3))
    {
        int tempA = cls1.PropertyA;
        foreach(var cls2 in cls1.dictObj2.Where(c2=> c2.MeasurementA >= 10))
        {
             double tempB = cls2.MeasurementB;
        }
    }
