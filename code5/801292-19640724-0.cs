    using System;
    using System.Collections.Generic;
    using System.Linq;
    // some additional namespaces
    namespace test
    {
       public partial class ProductFilter : CMSAbstractBaseFilterControl
       {
           protected IEnumerable<String> GetCategories(String parentName)
            {
                CategoryInfo info = CategoryInfoProvider.GetCategoryInfo(parentName, CMSContext.CurrentSite.SiteName);
                var children = CategoryInfoProvider.GetChildCategories(info.CategoryID, null, null, -1, null, CMSContext.CurrentSite.SiteID);
    
                children.AsEnumerable().ToArray();
            }
       }
    }
