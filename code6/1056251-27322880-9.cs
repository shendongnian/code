    var e = new ExtraEvilStruct();
    e.Mutable = new Mutable { MyVal = 1 };
    Datum<ExtraEvilStruct> datum = new Datum<ExtraEvilStruct>(new[] { e });
    e.Mutable.MyVal = 2;
    Console.WriteLine(datum[0].Mutable.MyVal); // 2
