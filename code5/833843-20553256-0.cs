    internal class ChildAgeComparer : IComparer<Parent>
    {
        public int Compare(Parent x, Parent y)
        {
            // First, find the ages of the children
            var xChildAges = GetAges(x);
            var yChildAges = GetAges(y);
            // Zip up matched children into tuples
            foreach (var pair in xChildAges.Zip(yChildAges, Tuple.Create))
            {
                // Compare each paired child in turn, returning if they're unequal
                if (pair.Item1.CompareTo(pair.Item2) != 0)
                    return pair.Item1.CompareTo(pair.Item2);
            }
            // Otherwise, see who had the larger number of children
            return xChildAges.Length.CompareTo(yChildAges.Length);
        }
        // A utility function to find and order the children's ages
        private static int[] GetAges(Parent parent)
        {
            return (
                from child in parent.Children
                let age = child.Age
                orderby age ascending
                select age
            ).ToArray();
        }
    }
