    using System.Linq;
    var fileEntries1 = Directory.GetFiles(folder1, "*.wav");
    var fileEntries2 = Directory.GetFiles(folder11, "*.wav");
    foreach (var entry1 in fileEntries1)
    {
        var entries = fileEntries2.Where(x => Equals(entry1, x));
        if (entries.Any())
        {
            //We have matches
            //entries is a list of matches in fileentries2 for entry1
        }
    }
