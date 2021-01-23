    public DifferenceFooObject(string sharedTest1, IEnumerable<FooSubObject> subTest1)
    {
        this.SharedTest1 = sharedTest1;
        this.SubTest1 = subTest1.ToList();
    }
