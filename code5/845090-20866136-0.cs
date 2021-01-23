    public static IEnumerable<Level1> Load(XElement root)
    {
        return root.Elements("level1")
                   .Select(l1 => {
                       var level1 = new Level1();
                       level1.Children = l1.Elements("level2").Select(l2 => {
                           var level2 = new Level2();
                           level2.Parent = level1;
                           level2.Children = l2.Elements("level3")
                                               .Select(l3 => new Level3() {
                                                   Parent = level2
                                               })
                                               .ToList();
                           return level2;
                       }).ToList();
                            
                       return level1;
                   });
    }
