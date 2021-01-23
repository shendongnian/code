    string[] lines = File.ReadAllLines("MyFile.txt");
    //List<string> lines2 = lines.ToList();
    // manipulate here your array of lines
    File.WriteAllLines("MyFile.txt", lines);
    //File.WriteAllLines("MyFile.txt", lines2.ToArray());
