    int i=0;
    printers.Add(delegate { Console.WriteLine(i); })
    i=1;
    printers.Add(delegate { Console.WriteLine(i); })
    ...
    i=10;
    printers.Add(delegate { Console.WriteLine(i); })
