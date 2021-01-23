    public class SubcategoryItem
    {
        public string Name { get; set; }
        public Action WhatItDoes { get; set; }
        public SubcategoryItem(string name, Action trick)
        {
            Name = name;
            WhatItDoes = trick;
        }
    }
    public abstract class AbsSubcategory
    {
        private static readonly IDictionary<Category, IList<SubcategoryItem>> mCategoriesMap = new Dictionary<Category, IList<SubcategoryItem>>();
        public abstract IList<SubcategoryItem> Subcategories { get; }
        
        protected AbsSubcategory(Category cat)
        {
            if (Subcategories != null) mCategoriesMap[cat] = Subcategories;
        }
    }
    public class VehiclesSubcategory : AbsSubcategory
    {
        private static readonly IList<SubcategoryItem> mSubcategories;
        public override IList<SubcategoryItem> Subcategories
        {
            get { return mSubcategories; }
        }
        static VehiclesSubcategory()
        {
            mSubcategories = new List<SubcategoryItem>()
            {
                new SubcategoryItem("Bikes", () => { /* Do something */ } ),
                new SubcategoryItem("Cars", () => { /* Do something */ } ),
            };
        }
        public VehiclesSubcategory()
            : base(Category.Vehicles)
        {
        }
    }
