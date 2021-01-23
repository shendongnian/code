    using System.Linq;
    var delim = new string[] { ", " };
    var stringArray = cn
        .Select(s => s.Split(delim, StringSplitOptions.None))
        .ToArray();
    var totalFrequency = stringArray
        .SelectMany(u => u)
        .GroupBy(s => s)
        .ToDictionary(g => g.Key, g => g.Count());
    var frequencyByUser = stringArray
        .Select(u => u
            .GroupBy(s => s)
            .ToDictionary(g => g.Key, g => g.Count()))
        .ToArray();
    var totalFrequencyOfText1 = totalFrequency["text1"];
    var frequncyOfText1ForUser2 = frequencyByUser[2]["text1"];
