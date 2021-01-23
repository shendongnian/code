    public class CharCount
    {
        public char Char { get; set; }
        public int FirstArrayCount { get; set; }
        public int SecondArrayCount { get; set; }
    }
    private static int CharMismatches(char[] a1, char[] a2, int max)
    {
        var charCountList = new List<CharCount>();
        charCountList.AddRange(a1.GroupBy(a => a).Select(a => new CharCount { Char = a.Key, FirstArrayCount = a.Count() }).ToList());
        charCountList.AddRange(a2.GroupBy(a => a).Select(a => new CharCount { Char = a.Key, SecondArrayCount = a.Count() }).ToList());
        var totalCharCountList= charCountList.GroupBy(a => a.Char).ToDictionary(a => a.Key, b => new CharCount
            {
                Char = b.Key,
                FirstArrayCount = b.Sum(c => c.FirstArrayCount),
                SecondArrayCount = b.Sum(c => c.SecondArrayCount)
            });
        var totalMisMatches= totalCharCountList.Count(a => a.Value.FirstArrayCount == 0 || a.Value.SecondArrayCount==0);
        return totalMisMatches;
    }
