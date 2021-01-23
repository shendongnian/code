            List<string> list = new List<string>();
            list.Add("Customers\\Order1");
            list.Add("Customers\\Order1\\Product1");
            list.Add("Customers\\Order2\\Product1");
            list.Add("Customers\\Order2\\Product1\\Price");
            var results = from item in list
                          from item2 in list
                          where item != item2
                            && item.StartsWith(item2)
                          select item;
            foreach (var item in results)
                Console.WriteLine(item);
            Console.ReadKey();
