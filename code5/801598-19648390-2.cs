    static void Test(IEnumerable<TreeItem<category>> categories, int deep = 0)
    {
        foreach (var c in categories)
        {
            Console.WriteLine(new String('\t', deep) + c.Item.Name);
            Test(c.Children, deep + 1);
        }
    }
