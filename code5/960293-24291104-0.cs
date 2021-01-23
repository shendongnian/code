    var bytes = id.ToByteArray();
    Console.WriteLine("Data1: {0:X8}", BitConverter.ToInt32(bytes, 0));
    Console.WriteLine("Data2: {0:X4}", BitConverter.ToInt16(bytes, 4));
    Console.WriteLine("Data3: {0:X4}", BitConverter.ToInt16(bytes, 6));
    Console.WriteLine("Data4: {0:X16}", BitConverter.ToInt64(bytes, 8));
