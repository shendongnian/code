     Int64 max = Int32.MaxValue;
     Console.WriteLine(max.ToString("X16")); // 000000007FFFFFFF
     Int64 min = Int32.MinValue;
     Console.WriteLine(min.ToString("X")); //FFFFFFFF80000000
     Int64 subtract = max - min;
     Console.WriteLine(subtract.ToString("X16")); //00000000FFFFFFFF <- not an overflow since it's a 64 bit number
     Int32 neg = -1
     Console.WriteLine(neg.ToString("X")); //FFFFFFFF
