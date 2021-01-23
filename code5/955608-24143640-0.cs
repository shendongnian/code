    [Test, Explicit]
    public void Test()
    {
      List<Rule> rules = new List<Rule>();
      Rule n = new Rule();
      rules.Add(n);
      Assert.AreEqual(n , rules.Last());
      Assert.AreEqual(0, rules.IndexOf(n));
    }
