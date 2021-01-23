     private static void RegisterServices(IKernel kernel)
            {
                Mock<IProductRepository> mock=new Mock<IProductRepository>();
                mock.Setup(x => x.Products).Returns(new List<Product>
                {
                    new Product {Name = "Football", Price = 23},
                    new Product {Name = "Surf board", Price = 179},
                    new Product {Name = "Running shose", Price = 95}
                });
                kernel.Bind<IProductRepository>().ToConstant(mock.Object);
            }        
        }
