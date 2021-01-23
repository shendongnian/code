            static List<string> GetCompatibles(IEnumerable<Compatible> table,
                                               string productId)
            {
                return table.Where(c => c.Prod1_id == productId)
                          .Select(c=>c.Prod2_id).ToList();
            }
