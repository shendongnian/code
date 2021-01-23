    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace MvcApplication1.Models
    {
        public class Repository
        {
            public NorthwindEntities northwind;
    
            public Repository()
            {
                northwind = new NorthwindEntities();
            }
    
            public Product GetProductById(Int32 ProductId)
            {
                return (from pro in northwind.Products
                        where pro.ProductID == ProductId
                        select pro).FirstOrDefault();
            }
    
            public void Save()
            {
                this.northwind.SaveChanges();
            }
        }
    }
------------------
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    using System.Web.Mvc;
    
    namespace MvcApplication1.Models
    {
        public class ProductEditViewModel
        {
            public Repository repository = new Repository();
    
            public Product Product;
    
            public ProductEditViewModel()
            {
                ;
            }
    
            // For DropDownListFor need IEnumerable<SelectListItem>
            public IEnumerable<SelectListItem> SupplierItems
            {
                get
                {
                    var q = from sup in repository.northwind.Suppliers.AsEnumerable()
                            select new SelectListItem
                                {
                                    Text = sup.CompanyName,
                                    Value = sup.SupplierID.ToString(),
                                    Selected = sup.SupplierID == Product.SupplierID
                                };
    
                    return q;
                }
            }
    
            // For RadioButtonFor need below
            public IEnumerable<Category> CategorieItems
            {
                get
                {
                    var q = from cat in repository.northwind.Categories.AsEnumerable() select cat;
                    return q;
                }
            }
        }
    }
