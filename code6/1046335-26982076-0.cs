            string[] Filter = {"Dep1","Dep2"}; //Easier if this is an enumerable
            var users = new List<Tuple<string, string>>
            {
                Tuple.Create("Meyer", "Dep1"),
                Tuple.Create("Jackson", "Dep2"),
                Tuple.Create("Green", "Dep1;Dep2"),
                Tuple.Create("Brown", "Dep1")
            };
            //I would use Any/Split/Contains
            var tuplets = users.Where(u => Filter.Any(y=> u.Item2.Split(';').Contains(y)));
            if (tuplets.Distinct().ToList().Count > 0)
            {
                foreach (var item in tuplets) Console.WriteLine(item.ToString());
            }
            else
            {
                Console.WriteLine("No results");
            }
