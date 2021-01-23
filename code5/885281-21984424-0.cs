    byte bit = 0x02;
    byte x = 0x0;
    
    // set
    x |= bit;
    Console.WriteLine(x); // 2
    
    // clear
    x &= (byte)~bit;
    Console.WriteLine(x); // 0
