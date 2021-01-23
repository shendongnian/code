    [TestMethod]
    public void One()
    {
        List<ValSeqGroup> items = new List<ValSeqGroup>()
        {
            new ValSeqGroup("x", 1, null),
            new ValSeqGroup("x", 4, null),
            new ValSeqGroup("x", 2, 1),
            new ValSeqGroup("x", 2, 2),
            new ValSeqGroup("x", 3, 1),
            new ValSeqGroup("x", 3, 2)
        };
        items.Sort(new ValSeqGroupComparer());
        foreach (var item in items)
        {
            Console.WriteLine("{0} {1} {2}", item.Value, item.Seq,item.Group);
        }
    }
