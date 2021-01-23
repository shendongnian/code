    static void Main(string[] args)
    {
        Tree<dynamic> intTree = CreateTree<dynamic>
            (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 15);
        Tree<dynamic> charTree = CreateTree<dynamic>
            ('1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'C', 'E');
        Tree<dynamic> months = CreateTree<dynamic>
            ("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec");
        IEnumerable<Tree<object>> list = 
            new List<Tree<object>> { intTree, charTree, months };
    }
    private static Tree<T> CreateTree<T>(params T[] values)
    {
        var t = new Tree<T>();
        var b = new Branch<T>();
        // some branching logic
        for (int i = 0; i < values.Length; i++)
        {
            if (i % 4 == 3)
            {
                b.Leaves.Add(values[i]);
                t.Branches.Add(b);
                b = new Branch<T>();
            }
            else
                b.Leaves.Add(values[i]);
        }
        if (b.Leaves.Count != 0)
            t.Branches.Add(b);
        return t;
    }
