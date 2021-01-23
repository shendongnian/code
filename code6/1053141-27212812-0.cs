    public class SubCategoryVM
    {
      public string Title { get; set; }
      public string Description { get; set; }
      public int ThreadsCount { get; set; }
      public int PostCount { get; set; }
    }
    public class CategoryVM
    {
      public string Name { get; set; }
      public List<SubCategoryVM> SubCategories { get; set; }
    }
