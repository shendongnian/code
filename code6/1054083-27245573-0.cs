        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("a.txt");
            var complexes = new Complex[lines.Length];
            for (int i = 0; i < complexes.Length; i++)
            {
                complexes[i] = Parse(lines[i]);
            }
        }
        private static Complex Parse(string s)
        {
            var split = s.Split(new char[' '], StringSplitOptions.RemoveEmptyEntries); // I guess string is something like "12 54". If you have "12 + 54i" you'l get an exception here
            return new Complex(double.Parse(split[0]), double.Parse(split[1]));
        }
