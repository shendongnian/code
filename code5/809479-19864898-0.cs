            var a = new MyCar() { id = 1, name = "a" };
            var b = new MyCar() { id = 1, name = "a" };
            var x = new List<MyCar>();
            x.Add(a);
            Console.WriteLine(a.Equals(b));
            Console.WriteLine(x.Contains(a));
            Console.WriteLine(x.Contains(b)); //all 3 are true
