            var items = new[] { 1, 2, 3}.AsEnumerable();
            items.ForEach(x =>
            {
                if (x == 3) throw new ArgumentException("3 is a bad number");
                Console.WriteLine(x.ToString());
            }).OnError(ex =>
            {
                Console.WriteLine(ex.Message);
            }).IfEmpty(() =>
            {
                Console.WriteLine("Empty");
            }).Execute();
