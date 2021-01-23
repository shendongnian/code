            string d = "M 0,20 40,20 40,80 0,80 z";
            Console.WriteLine(d);
            var replacePairs = new List<Tuple<string, int>>();
            d.Split(", ".ToCharArray()).ToList().ForEach((Action<string>)((x =>
            {
                int i;
                if (int.TryParse(x, out i))
                {
                    replacePairs.Add(Tuple.Create(x,2 * i));
                }
            })));
            var orderedreplacePairs = replacePairs.OrderByDescending(x => x.Item2).ToList();
            foreach (var orderedreplacePair in orderedreplacePairs)
            {
                d = d.Replace(orderedreplacePair.Item1, orderedreplacePair.Item2.ToString());
            }
            Console.WriteLine(d);
