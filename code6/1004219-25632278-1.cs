    using System.Linq;
    
    ...
    string[] productNameFromJoinedDatabase =
        _aPurchaseManager.GetProductNameWithCategoryAndBrandName().Select(purchase => purchase.ProductName).ToArray();
