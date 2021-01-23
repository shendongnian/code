    byte byteValue = 254;
    short shortValue = 10342;
    int intValue = 1023983;
    long lngValue = 6985321;               
    ulong ulngValue = UInt64.MaxValue;
    // Display integer values by caling the ToString method.
    Console.WriteLine("{0,22} {1,22}", byteValue.ToString("D8"), byteValue.ToString("X8"));
    Console.WriteLine("{0,22} {1,22}", shortValue.ToString("D8"), shortValue.ToString("X8"));
    Console.WriteLine("{0,22} {1,22}", intValue.ToString("D8"), intValue.ToString("X8"));
    Console.WriteLine("{0,22} {1,22}", lngValue.ToString("D8"), lngValue.ToString("X8"));
    Console.WriteLine("{0,22} {1,22}", ulngValue.ToString("D8"), ulngValue.ToString("X8"));
    Console.WriteLine();
    // Display the same integer values by using composite formatting.
    Console.WriteLine("{0,22:D8} {0,22:X8}", byteValue);
    Console.WriteLine("{0,22:D8} {0,22:X8}", shortValue);
    Console.WriteLine("{0,22:D8} {0,22:X8}", intValue);
    Console.WriteLine("{0,22:D8} {0,22:X8}", lngValue);
    Console.WriteLine("{0,22:D8} {0,22:X8}", ulngValue);
    // The example displays the following output: 
    //                     00000254               000000FE 
    //                     00010342               00002866 
    //                     01023983               000F9FEF 
    //                     06985321               006A9669 
    //         18446744073709551615       FFFFFFFFFFFFFFFF 
    //        
    //                     00000254               000000FE 
    //                     00010342               00002866 
    //                     01023983               000F9FEF 
    //                     06985321               006A9669 
    //         18446744073709551615       FFFFFFFFFFFFFFFF 
    //         18446744073709551615       FFFFFFFFFFFFFFFF
