    public static List<ProductObjectModel> GetProductsByKeyword(string keywords)
    {
        using (TraegerEntities db = new TraegerEntities())
        {
            List<ProductObjectModel> lstObj = new List<ProductObjectModel>();
    
            if (!string.IsNullOrEmpty(keywords))
            {
                string[] keyword = keywords.Split(',');
    
                List<ProductObjectModel> lstAnon  = (
                    from r in db.Products
                    join i in db.ProductImages on r.ProductId equals i.ProductId
                    join c in db.ProductCategories on r.ProductId equals c.ProductId
                    join cl in db.ProductCategoryList on c.ProductCategoryListId equals cl.ProductCategoryListId
                    join k in db.ProductKeywords on r.ProductId equals k.ProductId
                    join kl in db.ProductKeywordList on k.ProductKeywordListId equals kl.ProductKeywordListId
                    where r.Archive == false
                    where i.SmallImage == true
                    select new ProductObjectModel
                    {
                        Products = r,
                        CategoryList = cl,
                        KeywordList = kl,
                        Images = i
                    }
                ).ToList();
    
                var lstFiltered = lstAnon;
    
                List<string> keywordList = new List<string>(keywords.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
    
                foreach (string word in keywordList)
                {
                    var tempList = lstAnon.Where(r => r.KeywordList.Keyword == word).ToList();
                    lstFiltered = lstFiltered.Intersect(tempList, new MyEqualityComparer()).ToList();
                }
    
                foreach (var item in lstAnon.Skip(beginRange).Take(endRange))
                {
                    ProductObjectModel obj = new ProductObjectModel();
    
                    obj.Products = item.Products;
                    obj.CategoryList = item.ProductCategoryList;
                    obj.Images = item.ProductImages;
                    obj.KeywordList = item.ProductKeywordList;
    
                    lstObj.Add(obj);
                }
            }
    
            return lstObj;
        }
    }
    public class MyEqualityComparer : IEqualityComparer<ProductObjectModel>
    {
        public bool Equals(ProductObjectModel x, ProductObjectModel y)
        {
            return x.ProductObjectModel.ProductId == y.ProductObjectModel.ProductId;
        }
    
        public int GetHashCode(ProductObjectModelobj)
        {
            return obj.Products.ProductId.GetHashCode();
        }
    }
