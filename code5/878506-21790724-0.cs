        var sw = Stopwatch.StartNew();
        var x = new {MyEnumerator = new List<int>() { 1, 2, 3 }.GetEnumerator()};
        while (x.MyEnumerator.MoveNext())
            Console.WriteLine(x.MyEnumerator.Current);
        Debug.WriteLine(sw.Elapsed);
