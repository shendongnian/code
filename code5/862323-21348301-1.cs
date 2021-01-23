    using System.IO;
    using System.Linq;
    string filePath = @"D:\Path\To\The\File.txt";
    List<int[]> listOfArrays =
        File.ReadLines(path)
        .Select(line => line.Split(' ').Select(s => int.Parse(s)).ToArray())
        .ToList();
