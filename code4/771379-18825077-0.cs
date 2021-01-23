    public class Category : Entity<long>
    {
        public virtual IList<Category> ChildCategories
        {
            get;
            set;
        }
        public virtual Category ParentCategory
        {
            get;
            set;
        }
    }
