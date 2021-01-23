    public class Category
                {
                    public int ID { get; set; }
                    public string CategoryName { get; set; }
                    public int? ParentID { get; set; }
                    [ForeignKey("ParentID")]
                    public virtual ICollection<Category> SubCategories { get; set; }
                }
