            List<decimal> Prices = new List<decimal>();
            Prices.Add((decimal)999.99);
            Prices.Add((decimal)19.99);
            Prices.Add((decimal)2.75);
            Prices.Add((decimal)9.99);
            Prices.Add((decimal)2.99);
            Prices.Add((decimal)99.99);
            decimal minimum = Prices.Min();
            Prices = Prices.Select(price => price > minimum ? price : 0).ToList();
