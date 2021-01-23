        static List<string> GetAllCompatibles(List<Compatible> table,
            Product product, Product originalProduct, List<string> addedProducts)
        {
            List<string> result = new List<string>();
            //Gets all the directly compatible products
            var Childs = GetCompatibles(table, product.Id, originalProduct.Id, addedProducts);
            //Gets all the directly compatible products by retrocompatibility
            Childs.AddRange(GetCompatibles(table.Select(t =>
                            new Compatible { Prod1_id = t.Prod2_id, Prod2_id = t.Prod1_id }
                        ).ToList(), product.Id, originalProduct.Id, addedProducts));
            result.AddRange(Childs);
            addedProducts.AddRange(Childs);
            //Iterates over the directly compatible products
            foreach (string child in Childs)
            {
                //Again, get all the directly compatible products of the "child"
                var temp = GetAllCompatibles(table, new Product { Id = child }, 
                                             originalProduct, addedProducts);
                result.AddRange(temp);
                //If there are childs compatible products, adds it to the final result
                if (temp.Count > 0)
                {
                    result.AddRange(temp.Select(p =>
                            GetCompatibles(table, p, originalProduct.Id, addedProducts)
                        ).Aggregate((l1, l2) =>
                            { l1.AddRange(l2); return l1; })
                        );
                }
            }
            return result.Distinct().ToList();
        }
