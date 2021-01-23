    void Main()
    {
        // Given input
        var data = " 0100000000     Coffee\r\n 0110000000     Mocha\r\n 0120000000     Cappuccino\r\n 01210" +
            "00000     Semi skimmed\r\n 0121100000     Starbuckz\r\n 0121200000     Costa\r\n 01220" +
            "00000     Skimmed\r\n 0130000000     Latte";
        // Create the Line Data with basic information
        var lineData = 
            (from l in data.Split(new[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
            let pair = l.Split(new[]{' '},StringSplitOptions.RemoveEmptyEntries)
            select new LineData
            {
                OriginalCode = pair[0],
                Title = pair[1],
                Children = new List<LineData>()
            })
            .ToList();
        // Index each line by the part of the code that matters
        var linesByPrefix = 
            (from line in lineData
            let zeroIndex = line.OriginalCode.LastIndexOfAny(new[]{'1','2','3','4','5','6','7','8','9'}) + 1
            let untilZero = line.OriginalCode.Substring(0, zeroIndex)
            select new
        {
            untilZero,
            line
        })
        .ToDictionary(e => e.untilZero, e => e.line);
        // Populate the parent and child properties by looking up the parents of each
        // item.
        foreach (var line in linesByPrefix)
        {
            var parentCode = line.Key.Substring(0, line.Key.Length - 1);
            LineData parent;
            if(linesByPrefix.TryGetValue(parentCode, out parent))
            {
                line.Value.Parent = parent;
                parent.Children.Add(line.Value);
            }
        }
        var roots = lineData.Where(l => l.Parent == null);
    }
    
     public class LineData
     {
        public string OriginalCode { get; set; }
        public string Title { get; set; }
        public LineData Parent { get; set; }
        public List<LineData> Children { get; set; }
     }
