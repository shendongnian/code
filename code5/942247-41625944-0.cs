        var s = String.Empty;
        var min = Int32.MaxValue;
        foreach (var item in tempDictionary) {
            if (item.Value < min){
                s = item.Key;
                min = item.Value;
            }
        }
        Console.WriteLine(s + " => " + min);
