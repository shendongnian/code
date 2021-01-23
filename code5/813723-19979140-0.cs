    class Program
    {
        static void Main(string[] args)
        {
            var input = "and x = 'o'reilly' and y = 'o'reilly' and z = 'abc' ";
            var output = input
                .Select((c, i) => new { Character = c, Index = i })
                .Where(o =>
                {
                    if (o.Character != Convert.ToChar("'")) { return false; }
                    var i = o.Index;
                    var charBefore = (i == 0) ? false :
                        char.IsLetter(input[i - 1]);
                    var charAfter = (i == input.Length - 1) ? false :
                        char.IsLetter(input[i + 1]);
                    return charBefore && charAfter;
                })
                .ToList();
            foreach (var item in output)
            {
                input = input.Remove(item.Index, 1);
                input = input.Insert(item.Index, "\"");
            }
            Console.WriteLine(input);
            if (Debugger.IsAttached) { Console.ReadKey(); }
        }
    }
