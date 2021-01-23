            var lines = File.ReadAllLines(@"C:\randoms\randnum.txt");
            var ints = new List<int>();
            foreach (var line in lines)
            {
                foreach (var code in line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    ints.Add(int.Parse(code));
                }
            }
