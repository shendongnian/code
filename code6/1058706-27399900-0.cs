    string value = "ab, ac, Convert(ab,ac), test";
    string[] lines = Regex.Split(value, @", +");
    foreach (string line in lines) {
    Console.WriteLine(line);
    }
