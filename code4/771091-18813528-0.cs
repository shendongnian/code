     using System.Collections.Generic;
        using System.Linq;
        using NUnit.Framework;
        
        namespace StackOverflow
        {
            [TestFixture]
            public class ProductListQuestion
            {
                class ProductEntity
                {
                    public string Name { get; set; }
                    public decimal Price { get; set; }
                    public string OtherProperty { get; set; }
                }
        
                [Test]
                public void CanSelectProperties()
                {
                    var products = new List<ProductEntity>
                    {
                        new ProductEntity {Name = "First", Price = 1M},
                        new ProductEntity {Name = "Second", Price = 2M},
                        new ProductEntity {Name = "Third", Price = 3M}
                    };
        
                    var productList = products
                       .Select(p => new {  p.Name, p.Price });
        
                    Assert.That(productList, Is.Not.Null);
                    Assert.That(productList.Count(), Is.EqualTo(3));
                    Assert.That(productList.ElementAt(0), Has.No.Property("OtherProperty"));
                    Assert.That(productList.ElementAt(0), Has.Property("Name"));
        
                }
            }
        }
