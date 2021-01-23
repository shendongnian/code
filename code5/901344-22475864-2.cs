    public class CategoryTree : IEnumerable<CategoryNode> {
      private List<CategoryNode> innerList = new List<CategoryNode>();
	
      public CategoryTree(IEnumerable<CategoryNode> nodes) {
        innerList = new List<CategoryNode>(nodes);	
      }
	
      public IEnumerator<CategoryNode> GetEnumerator()
      {
        return innerList.GetEnumerator();
      }
      System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
      {
        return this.GetEnumerator();
      }
    
      public IEnumerable<CategoryNode> Flatten() {
        foreach(var category in innerList.OrderBy(o => o.SortOrder)) {
          yield return category;
          
          if (category.Children != null) {
            foreach(var child in category.Children.Flatten()) {
              yield return child;
            }
          }
        }
      }
      public static CategoryTree Create(
        IEnumerable<Category> categories, 
        Func<Category, bool> parentPredicate, 
        int level = 0) 
      {
        var nodes = categories
          .Where(parentPredicate)
          .OrderBy(o => o.SortOrder)
          .Select(item => new CategoryNode(item) { 
            Level = level,
            Children = Create(categories, o => o.ParentCategoryId == item.Id, level + 1)
          });
      
        return new CategoryTree(nodes);
      }
    }    
