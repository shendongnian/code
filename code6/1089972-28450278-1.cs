    static void Main()
    {
        var test1 = new Logger<DataType1>(t => t.Read());
        test1.Read(); // Will be equal "dt1";
    
        var test2 = new Logger<DataType2>(t => t.Read());
        test2.Read(); // Will be equal "dt2";
    }
