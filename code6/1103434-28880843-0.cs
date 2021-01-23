    foreach(string line in File.ReadLines(@"c:\file path here")) {
        if (Regex.Test(expr, line)) {
            Console.WriteLine(line);
        }
    }
