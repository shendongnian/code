    public class Categories : BaseINotifyCollectionChanged<Category, string>
    {
        long _onCategoryRoot;
        public void SetOnCategoryRoot(long categoryId)
        {
            _onCategoryRoot = categoryId;
            RaiseCollectionChanged();
        }
        protected override IList<Category> GetCollection()
        {
            Category category = new Category();
            return _onRoot ? category.GetRootCategories() : category.GetSubCategoriesOnRoot(_onCategoryRoot);
        }
    }
