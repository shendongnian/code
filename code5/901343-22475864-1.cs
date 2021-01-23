    public class CategoryNode : Category {
      public CategoryNode(Category category) {
        Id = category.Id;
        ParentCategoryId = category.ParentCategoryId;
        SortOrder = category.SortOrder;
        Text = category.Text;
      }
   
      public CategoryTree Children { get; set; }
      public int Level { get; set;}
      public string DisplayText { 
        get { 
          // OP wants two-dots prefix per level
          return string.Concat(new string('.', Level*2), Text); 
        }
      }
    }
