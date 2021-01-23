    var global = new List<GlobalListTable>()
            {
                new GlobalListTable()
                {
                    ProductListTypeId = 1,
                    ProductGroupTable = new ProductGroupTable()
                    {
                        ProductTables = new List<ProductTable>()
                        {
                            new ProductTable()
                            {
                                ComponentTables = new List<ComponentTable>()
                                {
                                    new ComponentTable(){ComponentTypeId = 4, Name = "Sucess"}
                                }
                            }
                        }
                    }
                }
            };
            var productListTypeId=1;    
            var componentTypeId=4;
            var query =
                global.Where(t => t.ProductListTypeId == productListTypeId)
                    .Select(t => t.ProductGroupTable)
                    .SelectMany(t => t.ProductTables)
                    .SelectMany(t => t.ComponentTables)
                    .Where(t => t.ComponentTypeId == componentTypeId);
