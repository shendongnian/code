        [Fact]
        public void Test()
        {
            Type baseClass = typeof(Class1);
            var result = (from type in Assembly.GetExecutingAssembly().GetTypes()
                          where type.IsSubclassOf(baseClass)
                          let index = Regex.Match(type.Name, @"\d+$")
                          where string.IsNullOrWhiteSpace(index.Value) == false
                          select new ResultItem { Index = int.Parse(index.Value), Type = type })
                          .OrderBy(x=>x.Index)
                          .ToList();
            result.ForEach(Console.WriteLine);
        }
        public class Class1
        {
        }
        public class Class2 : Class1
        {
        }
        public class Class3 : Class1
        {
        }
        private sealed class ResultItem
        {
            public int Index { get; set; }
            public Type Type { get; set; }
            public override string ToString()
            {
                return string.Format("Index: {0}, Type: {1}", Index, Type.Name);
            }
        }
