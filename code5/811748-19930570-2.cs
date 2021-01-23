    internal class Program
    {
        private static void Main(string[] args)
        {
            var inputs = new List<string>();
            for (int i = 0; i < 10000000; i++)
            {
                inputs.Add("ABC1234");
            }
            var n1 = DateTime.Now;
            inputs.ForEach(i => ExpandCode1(i));
            var r1 = (DateTime.Now - n1).Ticks;
            var n2 = DateTime.Now;
            inputs.ForEach(i => ExpandCode2(i));
            var r2 = (DateTime.Now - n2).Ticks;
            var n3 = DateTime.Now;
            inputs.ForEach(i => ExpandCode3(i));
            var r3 = (DateTime.Now - n3).Ticks;
            var n4 = DateTime.Now;
            inputs.ForEach(i => ExpandCode4(i));
            var r4 = (DateTime.Now - n4).Ticks;
            var results = new List<Result>()
            {
                new Result() {Name = "1", Ticks = r1},
                new Result() {Name = "2", Ticks = r2},
                new Result() {Name = "3", Ticks = r3},
                new Result() {Name = "4", Ticks = r4}
            };
            results.OrderBy(r => r.Ticks).ToList().ForEach(Console.WriteLine);
            Console.ReadKey();
        }
        public static string ExpandCode4(string s)
        {
            char[] res = new char[15];
            int ind = 0;
            for (int i = 0; i < s.Length && s[i] >= 'A'; i++)
                res[ind++] = s[i];
            int tillDigit = ind;
            for (int i = 0; i < 15 - s.Length; i++)
                res[ind++] = '0';
            for (int i = 0; i < s.Length - tillDigit; i++)
                res[ind++] = s[tillDigit + i];
            return new string(res);
        }
        public static string ExpandCode1(string s)
        {
            char[] numbers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            //Find the first numeric char.
            int index = s.IndexOfAny(numbers);
            //Insert zeros and return the result. 
            return s.Insert(index, new String('0', 15 - s.Length));
        }
        public static string ExpandCode2(string s)
        {
            var builder = new StringBuilder(s);
            var index = Array.FindIndex(s.ToArray(), x => char.IsDigit(x));
            while (builder.Length < 15)
            {
                builder.Insert(index, '0');
            }
            return builder.ToString();
        }
        public static string ExpandCode3(string s)
        {
            var match = Regex.Match(s, @"([^\d]+)(\d+)");
            var letters = match.Groups[1].Value;
            var numbers = int.Parse(match.Groups[2].Value);
            var formatString = "{0}{1:d" + (15 - letters.Length) + "}";
            var longForm = string.Format(formatString, letters, numbers);
            return longForm;
        }
    }
    public class Result
    {
        public long Ticks { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name + " - " + Ticks;
        }
    }
