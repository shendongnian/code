    // not iesi
    // we need System
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    ...
    
    public class ProductCategoryModel
    {
        ...
        // could be used just as navigation property
        public virtual int parentId { get; set; }
        // This is must with inverse="true"
        public virtual ProductCategoryModel Parent { get; set; }
        // the System.Collections.Generic
        public virtual ISet<ProductCategoryModel> SubCategories { get; set; }
        ...
