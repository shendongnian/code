    string s = "1 12 94 201 198";
    string[] groups = s.Split();
    long result = 0;
    foreach (string hexGroup in groups) {
        result = 256 * result + Int32.Parse(hexGroup);
    }
    Console.WriteLine(result); // ==> 4502505926
