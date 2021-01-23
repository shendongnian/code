                Product product = new Product { Id = "1" };
            //Gets all the compatible products 1 -> X
            List<string> compatibility = GetAllCompatibles(table, product, product); 
            // Reverses the table to get all the compatible products X -> 1:
            List<string> retroCompatibility = 
                    GetAllCompatibles(
                        table.Select(t => 
                            new Compatible { Prod1_id = t.Prod2_id, Prod2_id = t.Prod1_id }
                        ).ToList(),
                    product, product).ToList();
            //Does an UNION of the two compatibility lists
            var result = compatibility.Union(retroCompatibility).ToList();
