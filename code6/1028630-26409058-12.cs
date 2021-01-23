        static List<string> GetCompatibles(IEnumerable<Compatible> table,
            string productId, string originalId, List<string> addedProducts)
        {
            return table.Where(c =>
                    (c.Prod1_id == productId &&
                    c.Prod2_id != originalId &&
                    !addedProducts.Contains(c.Prod2_id))
                ).Select(c => c.Prod2_id).ToList();
        }
