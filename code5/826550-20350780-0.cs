    internal class TestComparer : IEqualityComparer<test>
    {
        public bool Equals(test x, test y)
        {
            if (x.Scores.Count != y.Scores.Count)
                return false;
            return new HashSet<int>(x.Scores).SetEquals(y.Scores);
        }
        public int GetHashCode(test obj)
        {
            return obj.Scores.Aggregate((seed,x)=> seed | x);
        }
    }
    var filteredList = tests.Distinct(new TestComparer()).ToList();
