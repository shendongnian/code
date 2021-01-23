        static void Main(string[] args)
        {
            var data = new List<Thing> { new Thing { First = "Alex", Group = "Sams" }, new Thing { First = "John", Group = "Sams" }, new Thing { First = "", Group = "Sams" }, new Thing { First = "Sue", Group = "Freds" } };
            var results = from item in data
                          group item by item.Group into g
                          select g;
            List<Thing> list = new List<Thing>();
            foreach (var item in results)
            {
                if (item.Count() > 1)
                {
                    Thing parent = item.Where(x => String.IsNullOrEmpty(x.First)).First();
                    parent.First = "";
                    parent.Group = item.First().Group;
                    parent.Things = item.Where(x => x != parent).ToList();
                    list.Add(parent);
                }
                else
                {
                    list.Add(item.First());
                }
            }
        }
