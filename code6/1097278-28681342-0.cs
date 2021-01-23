     var products = new List<object>();
            var f1 = new Fruits("Apple", 25.34, 5);
            var f2 = new Fruits("Orange", 18.19, 3);
            products.Add(f1);
            products.Add(f2);
            String ss = "Item\t\tWeight\t\tQty\n";
            for (int i = 0; i < 60; i++) ss += "-";
            Console.WriteLine(ss);
            foreach (var item in products)
            {
                Console.WriteLine(item.Name.ToString() + "\t\t" + item.Weight.ToString() + "\t\t" + item.Quantity.ToString());
            }
