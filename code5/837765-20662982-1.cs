    List<string> input = new List<string>
    {
        "idCategory,nameCategory,idProduct,nameProduct,price",
        "0,Shoes,0,Jordan,99.9",
        "0,Shoes,1,Nike,59.9",
        "0,Shoes,2,Adidas,85.6",
        "0,Shoes,3,NewFeel,11.0",
        "1,watch,6,Armani,59.9",
        "1,watch,8,CK,85.6",
        "1,watch,9,Rolex,11.0",
    };
    List<Category> categories = new List<Category>();
    foreach(string s in input.Skip(1))
    {
        string[] temp = s.Split(',');
        if(categories.Contains<Category>(new Category
        {
            idCategory = int.Parse(temp[0])
        }, new CategoryEquality()))
            categories.Find(id => id.idCategory == int.Parse(temp[0])).products.Add(new Product
            {
                idProduct = int.Parse(temp[2]),
                nameProduct = temp[3],
                price = float.Parse(temp[4])
            });
        else
            categories.Add(new Category
            {
                idCategory = int.Parse(temp[0]),
                nameCategory = temp[1],
                products = new List<Product> 
                { new Product 
                    { 
                        idProduct = int.Parse(temp[2]), 
                        nameProduct = temp[3], 
                        price = float.Parse(temp[4]) 
                    } 
                }
            });
    }
        public class CategoryEquality : IEqualityComparer<Category>
        {
            public bool Equals(Category a, Category b)
            {
                return a.idCategory == b.idCategory;
            }
            public int GetHashCode(Category a)
            {
                return a.idCategory.GetHashCode();
            }
        }
        public class Category
        {
            public int idCategory
            {
                get;
                set;
            }
            public string nameCategory
            {
                get;
                set;
            }
            public List<Product> products
            {
                get;
                set;
            }
        }
        public class Product
        {
            public int idProduct
            {
                get;
                set;
            }
            public string nameProduct
            {
                get;
                set;
            }
            public float price
            {
                get;
                set;
            }
        }
