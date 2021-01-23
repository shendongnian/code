            var query = from i in list
                        group i by new { i.Value, i.Qux } into g
                        orderby g.Count() descending, g.Key.Value
                        select g;
            foreach (var group in query)
            {
                foreach (var item in group)
                    Console.WriteLine("{0} {1} {2} [Original object? {3}]",
                        item.Value,
                        item.Qux,
                        item.Quux,
                        list.Contains(item));
                Console.WriteLine("-");
            }
