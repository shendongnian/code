    public partial class Category
    {
     public int CategoryId { get; set; }
     public string Title { get; set; }
     
     public virtual MyApp.Models.Problems Problem { get; set; }//Add this line to respect the one-many config
    }
    public partial class Type
    {
    public int TypeId { get; set; }
    public int Order { get; set; }
    public string Description { get; set; }
    public virtual MyApp.Models.Problems Problem { get; set; }//Add this line to respect the one-many config
    }
