    public class MySpecificOrdering : OrderedPredicatesComparer<string>
    {
        private static readonly Func<string, bool>[] order = new Func<string, bool>[]
            {
                x => x.StartsWith("ProjectDescription_"),
                x => x.StartsWith("Budget_"),
                x => x.StartsWith("CV_"),
            };
        public MergeOrderComparer() : base(order) {}
    }
    var files = GetFiles()
        .OrderBy(x => x.Filename, new MySpecificOrdering())
        .ThenBy(x => x.Filename)
        .ToArray();
