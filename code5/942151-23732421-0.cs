            var a = new List<int> { 1, 2, 3 };
            var b = new List<int> { 3, 4, 5 };
            var c = a.Intersect(b).ToList();
            Console.WriteLine(string.Join(",",c.Select(c1 => c1+"").ToArray()));
            Console.ReadKey();
