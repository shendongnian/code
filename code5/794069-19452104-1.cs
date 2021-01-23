    public class Program
    {
        public int Int { get; set; }
        public string str;
        public static IEnumerable<T> getMatches<T>(List<T> list, string search) {
            if (search == null)
                throw new ArgumentNullException("search");
            return list.Select(x => new
            {
                X = x,
                Props = x.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public),
                Fields = x.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public),
            })
            .Where(x => x.Props.Any(p =>
                                {
                                    var val = p.GetValue(x.X, null);
                                    return val != null && val.ToString().Contains(search);
                                })
                        || x.Fields.Any(p =>
                                {
                                    var val = p.GetValue(x.X);
                                    return val != null && val.ToString().Contains(search);
                                }))
            .Select(x => x.X);
        }
        static void Main(string[] args)
        {
            List<Program> list = new List<Program>{
                new Program { Int = 0, str = "foo bar" },
                new Program { Int = 54, str = "foo 0 bar" },
                new Program { Int = 12, str = "foo bar" },
                new Program { Int = 720, str = "foo bar" }
            };
            foreach (var item in getMatches(list, "0"))
            {
                Console.WriteLine("Int = " + item.Int + ", str = " + item.str);
            }
        }
    }
