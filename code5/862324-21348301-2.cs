    using System.IO;
    using System.Linq;
    string filePath = @"D:\Path\To\The\File.txt";
    IEnumerable<string> linesFromFile = File.ReadLines(path);
    Func<string, int[]> convertStringToIntArray =
        line => {
            var stringArray = line.Split(' ');
            var intSequence = stringArray.Select(s => int.Parse(s)); // or ....Select(Convert.ToInt32);
            var intArray = intSequance.ToArray();
            return intArray;
        };
    IEnumerable<int[]> sequenceOfIntArrays = linesFromFile.Select(convertStringToIntArray);
    List<int[]> listOfInfArrays = sequenceOfIntArrays.ToList();
