    var dt1 = new DataType1();
    var dt2 = new DataType2();
    var logger1 = new Logger<DataType1>(dt1);
    var logger2 = new Logger(dt2); // can omit generic noise!
    Console.WriteLine(logger1.Read()); // "dt1"
    Console.WriteLine(logger2.Read()); // "dt2"
