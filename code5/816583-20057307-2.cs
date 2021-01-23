    IntPtr pointer = LoadImage(IntPtr.Zero, path, 0, 256, 256, 0x00008010);
    if (pointer == NULL) {
        uint result = GetLastError();
        // Console.WriteLine(pointer); // useless, has to be NULL
        Console.WriteLine(result);
        Console.ReadLine();
    }
