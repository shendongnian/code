    #region Terrible Object
 
    var hasAllTheItems =
            new[]
            {
                    new[]
                    {
                            new
                            {
                                    Name = "Test"
                            }
                    },
                    new[]
                    {
                            new
                            {
                                    Name = "Test2"
                            },
                            new
                            {
                                    Name = "Test3"
                            }
                    }
            };
 
    #endregion Terrible Object
 
    var a = hasAllTheItems.Select(x => x.Select(y => y.Name));
    var b = hasAllTheItems.SelectMany(x => x.Select(y => y.Name));
    var c = hasAllTheItems.Select(x => x.SelectMany(y => y.Name));
    var d = hasAllTheItems.SelectMany(x => x.SelectMany(y => y.Name));
 
    Assert.AreEqual(2, a.Count());
    Assert.AreEqual(3, b.Count());
    Assert.AreEqual(2, c.Count());
    Assert.AreEqual(14, d.Count());
A: {{Test}, {Test2, Test3}}
B: {Test, Test2, Test3}
C: {{T, e, s, t}, {T, e, s, t, 2, T, e, s, t, 3}}
D: {T, e, s, t, T, e, s, t, 2, T, e, s, t, 3}
