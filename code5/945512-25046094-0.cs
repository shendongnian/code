     Int64 max = Int32.MaxValue;
     Console.WriteLine(max.ToString("X")); // 7FFFFFFF
     Int64 min = Int32.MinValue;
     Console.WriteLine(min.ToString("X")); //FFFFFFFF80000000
     Int64 subtract = max - min;
     Console.WriteLine(subtract.ToString("X")); //FFFFFFFF
     Int32 neg = -1
     Console.WriteLine(neg.ToString("X")); //FFFFFFFF
