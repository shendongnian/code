               int[] input = Array.ConvertAll(line.Split(' '), int.Parse);
                int[] input2 = Array.ConvertAll(line.Split(' '), int.Parse);
                var tempIndex = input.Distinct().Select(a => input2.ToList().IndexOf(a));
                foreach (var index in tempIndex.ToList())
                {
                    Console.WriteLine(index);
                }
