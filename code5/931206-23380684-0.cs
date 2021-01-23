    public static void ToCSV(string fileWRITE, string fileREAD)
    {
        string[] lines = File.ReadAllLines(fileREAD);
        string[] splitLines = lines.Select(s => Regex.Replace(s, "(.{5})(.)(.{3})(.*)", "$1,$2,$3,$4")).ToArray();
        File.WriteAllLines(fileWRITE, splitLines);
    }
