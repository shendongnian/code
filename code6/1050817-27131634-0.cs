    List<Category> categories = new List<Category>
               {
                   new Category { subCats = new _SubCategories { ID =1, ParentID = 4}, ParenttIds = new List<int> { 2,4,7}},
                   new Category { subCats = new _SubCategories { ID =2, ParentID = 2}, ParenttIds = new List<int> { 4,3,8}},
                   new Category { subCats = new _SubCategories { ID =3, ParentID = 8}, ParenttIds = new List<int> { 2,8,4}}
               };
    
    public class Category
        {
            public _SubCategories subCats { get; set; }
            public List<int> ParenttIds { get; set; }
        }
    
        public class _SubCategories
        {
            public int ID { get; set; }
            public int ParentID  { get; set; }
        }
