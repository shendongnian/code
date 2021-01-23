     public class ProductDTO
     {
         public int Id { get; set; }
         public string Name { get; set; }
         public int? Parent { get; set; }
     }
    
     var products = new List<ProductDTO>();
     products.Add(new ProductDTO() { Id = 1, Name = "Product One" });
     products.Add(new ProductDTO() { Id = 2, Name = "Product Two" });
     products.Add(new ProductDTO() { Id = 3, Name = "Product Three" });
     products.Add(new ProductDTO() { Id = 4, Name = "Child One", Parent=1 });
     products.Add(new ProductDTO() { Id = 5, Name = "Child Two", Parent = 2 });
     products.Add(new ProductDTO() { Id = 6, Name = "Child One", Parent = 1 });
     
    var ordered = products
                    .Where(p => p.Parent == null)
                    .OrderBy(p=> p.Id)
                    .Select(p => products
                        .Where(c => c.Parent == p.Id)
                        .OrderBy(c => c.Id))
                    .ToList();
