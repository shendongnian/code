        static void Main(string[] args)
        {
            int[] width = new int[2] { 10, 20 };
            int[] height = new int[2] { 30, 40 };
            var wholeList = width.Select(val => new IndexValuePair() { Index = "width", Value = val }).ToList();
            var heightList = height.Select(val => new IndexValuePair() { Index = "height", Value = val }).ToList();
            var iteration = 0;
            wholeList.ForEach(ivp => { ivp.Index = ivp.Index + count; count = iteration + 1; });
            iteration = 0;
            heightList.ForEach(ipv => { ivp.Index = ivp.Index + count; count = iteration + 1; });
            wholeList.AddRange(heightList);
            var sumOfCombinations = GetPowerSet(wholeList).Where(x => x.Count() > 0)
                 .Select(x => new { Combination = x.ToList(), Sum = x.Sum(ivp => ivp.Value) }).ToList();
            StringBuilder sb = new StringBuilder();
            sumOfCombinations.ForEach(ivp =>
            {
                ivp.Combination.ForEach(pair => sb.Append(string.Format("{0} ", pair.Value)));
                sb.Append(string.Format("= {0} = ", x.Sum));
                ivp.Combination.ForEach(pair=> sb.Append(string.Format("{0} + ", pair.Index)));
                sb.Length -= 3;
                Console.WriteLine(sb);
                sb.Clear();
            });
            var key = Console.ReadKey();
        }
