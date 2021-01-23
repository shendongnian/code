    using System.Linq;
    var stringArray = new string[]{ "text1", "text2", "text3", "text4", "text6", ... };
    var frequencies = stringArray
        .GroupBy(s => s)
        .ToDictionary(g => g.Key, g => g.Count());
    var exampleFrequency = frequencies["text1"]
