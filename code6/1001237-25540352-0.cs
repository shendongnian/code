    string[] parts = Regex.Split(input, @"(?<!\A)(?<!-)(?=--(?!-))");
    int i = 1;
    foreach (string m in parts) {
             Console.WriteLine("MATCH " + i + ":" + m); ++i;
    }
