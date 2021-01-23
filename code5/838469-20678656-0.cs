     using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Tags> tagList = new List<Tags>();
                tagList.Add(new Tags { TagId = 1, Title = "Cacao" });
                tagList.Add(new Tags { TagId = 2, Title = "Banana" });
                tagList.Add(new Tags { TagId = 3, Title = "Chevy" });
                tagList.Add(new Tags { TagId = 4, Title = "Nuts" });
    
                List<Products> productList = new List<Products>();
                productList.Add(new Products { Id = 1,Title= "Chocolate" });
                productList.Add(new Products { Id = 2,Title= "Chocolate" });
    
                List<ProductsTag> pTagList = new List<ProductsTag>();
                pTagList.Add(new ProductsTag { Id = 1, ProductId = 1, TagId = 1 });
                pTagList.Add(new ProductsTag { Id = 2, ProductId = 1, TagId = 4 });
                pTagList.Add(new ProductsTag { Id = 3, ProductId = 2, TagId = 1 });
    
                List<string> missingstuff = new List<string>();
    
                foreach (var i in tagList)
                {
                    int index = pTagList.FindIndex(item => item.TagId == i.TagId);
                    if (index < 0) 
                    {
                         missingstuff.Add(i.Title);                  
                    }                             
                }
            }
    
            public class Tags
    {
        public int TagId {get;set;}
        public string Title {get;set;}
    }
    
    public class Products
    {
        public int Id {get;set;}
        public string Title {get;set;}
    }
    
    public class ProductsTag
    {
        public int Id {get;set;}
        public int ProductId {get;set;}
        public int TagId {get;set;}
    }
    
    
        }
    
    }
