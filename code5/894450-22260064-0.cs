    namespace Order.Models
    {
        public class CategoriesViewModel
        {
            public IEnumerable<RestCategories> Categories;
            public List<ListRestItem> Items;
        }
        public class ListRestItem
        {
           public int CategoryId;
           public List<RestItem> Items;
        }
