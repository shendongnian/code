    var value = (int)info.dwPrinterDriverAttributes;
    BitArray b = new BitArray(new int[] { value } );
    bool[] bits = new bool[b.Count];
    b.CopyTo(bits, 0);
    if (bits[1]) 
        Console.WriteLine("flag set");
    else
        Console.WriteLine("flag not set");
