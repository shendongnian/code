    int i = 0;
    // Set 5th bit
    i |= 1 << 5;
    Console.WriteLine(i); // 32
    // Clear 5th bit
    i &= ~(1 << 5);
    Console.WriteLine(i); // 0
