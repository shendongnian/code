    [Given(@"foo ((?:.,\d+)*(?:.+))")]
    public void Foo(IEnumerable<int> ints)
    {
    }
    
    [StepArgumentTransformation(@"((?:.,\d+)*(?:.+))")]
    public static IEnumerable<int> ListIntTransform(string ints)
    {
        return ints.Split(new[] { ',' }).Select(int.Parse);
    }
