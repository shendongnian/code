    public static class myExt
      {
        public static List<Parent> OrderByWithTieBreaker(this List<Parent> parents, int depth = 0)
        {
          if (depth > parents[0].Children.Count())
            return parents;
          var returnedList = new List<Parent>();
    
          Func<Parent, int> keySelector = x =>
        {
          IEnumerable<Child> enumerable = x.Children.OrderBy(y => y.Age).Skip(depth);
          if (!enumerable.Any())
            return 0; //If no children left, then return lowest possible age
          return enumerable.Min(z => z.Age);
        };
          var orderedParents = parents.OrderBy(keySelector);
          var groupings = orderedParents.GroupBy(keySelector);
          foreach (var grouping in groupings)
          {
            if (grouping.Count() > 1)
            {
              var innerOrder = grouping.ToList().OrderByWithTieBreaker(depth + 1);
              returnedList = returnedList.Union(innerOrder).ToList();
            }
            else
              returnedList.Add(grouping.First());
          }
          return returnedList;
        }
      }
      [TestFixture]
      public class TestClass
      {
        public class Parent { public string Name { get; set; } public List<Child> Children { get; set; } }
        public class Child { public int Age {get;set;} }
    
        [Test]
        public void TestName()
        {
          var parents = new List<Parent>
            {
              new Parent{Name="P3", Children = new List<Child>{new Child{Age=1}, new Child{Age=3}, new Child{Age=6}, new Child{Age=7}}},
              new Parent{Name="P4", Children = new List<Child>{new Child{Age=1}, new Child{Age=3}, new Child{Age=6}, new Child{Age=7}}},
              new Parent{Name="P2", Children = new List<Child>{new Child{Age=1}, new Child{Age=3}, new Child{Age=6}}},
              new Parent{Name="P1", Children = new List<Child>{new Child{Age=1}, new Child{Age=2}, new Child{Age=7}}},
              new Parent{Name="P5", Children = new List<Child>{new Child{Age=1}, new Child{Age=4}, new Child{Age=5}}}
            };
          var f = parents.OrderByWithTieBreaker();
          int count = 1;
          foreach (var d in f)
          {
            Assert.That(d.Name, Is.EqualTo("P"+count));
            count++;
          }
        }
