    var test = new Test
    {
        SubTestList = new List<SubTest>
        {
          new SubTest
          {
              Name = "Name1",
          },
          new SubTest
          {
            Name  = "Name2",
          },
        },
    };
    collection.Insert(test);
