    @"C:\\test.txt"; // <==NEW
    StreamWriter sw = new StreamWriter(new FileStream(path, Filemode.Append, FileAccess.Write)); // <==NEW
    StringBuilder Editions = new StringBuilder(400);
    
    
    Editions.Insert(0, "0");
    Editions.Insert(1, "0");
    //Editions.Remove(9, 14);
    //Editions.Insert(11, "R");
    //Editions.Insert(12, "M");
    //Editions.Insert(13, "A");
    //Editions.Insert(14, "L");
    //Editions.Insert(15, "L");
    //Editions.Insert(16, " ");
    //Editions.Insert(17, " ");
    //Editions.Insert(18, " ");
    //Editions.Insert(193, "C");
    //Editions.Insert(194, "L");
    sw.Write(Editions.ToString()); // <== NEW
    sw.Flush(); // <== NEW
    sw.Close(); // <== NEW
