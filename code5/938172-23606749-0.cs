        static IEnumerable<Person> InventPeople(int seed, int count)
        {
            for(int i = 0; i < count; i++)
            {
                int f = 1 + seed + i;
                var item = new Person
                {
                    Id = f,
                    Name = Path.GetRandomFileName().Replace(".", "").Substring(0, appRandom.Value.Next(3, 6)) + " " + Path.GetRandomFileName().Replace(".", "").Substring(0, new Random(Guid.NewGuid().GetHashCode()).Next(3, 6)),
                    Age = f % 90,
                    Friends = ParallelEnumerable.Range(0, 100).Select(n => appRandom.Value.Next(1, f)).ToArray()
                };
                yield return item;
            }
        }
        static IEnumerable<T> Batchify<T>(this IEnumerable<T> source, int count)
        {
            var list = new List<T>(count);
            foreach(var item in source)
            {
                list.Add(item);
                if(list.Count == count)
                {
                    foreach (var x in list) yield return x;
                    list.Clear();
                }
            }
            foreach (var item in list) yield return item;
        }
