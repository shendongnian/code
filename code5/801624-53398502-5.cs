     //Test Item
     public class TestTreeItem
     {
         public int Id { get; set; }
         public int ParentId { get; set; }
         public string Name { get; set; }
     }
     //Usage
     var collection = new List<TestTreeItem>
     {
          new TestTreeItem {Id = 1, Name = "1", ParentId = 14},
          new TestTreeItem {Id = 2, Name = "2", ParentId = 0},
          new TestTreeItem {Id = 3, Name = "3", ParentId = 1},
          new TestTreeItem {Id = 4, Name = "4", ParentId = 1},
          new TestTreeItem {Id = 5, Name = "5", ParentId = 2},
          new TestTreeItem {Id = 6, Name = "6", ParentId = 2},
          new TestTreeItem {Id = 7, Name = "7", ParentId = 3},
          new TestTreeItem {Id = 8, Name = "8", ParentId = 3},
          new TestTreeItem {Id = 9, Name = "9", ParentId = 5},
          new TestTreeItem {Id = 10, Name = "10", ParentId = 7}
      };
      var tree = collection.ToTree(item => item.Id, item => item.ParentId);
