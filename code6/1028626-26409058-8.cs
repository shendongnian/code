        static List<string> GetCompatibles(IEnumerable<Compatible> table, 
            string productId, string originalId)
        {
            return table.Where(c => 
                    (c.Prod1_id == productId && c.Prod2_id != originalId)
                ).Select(c=>c.Prod2_id).ToList();
        }
