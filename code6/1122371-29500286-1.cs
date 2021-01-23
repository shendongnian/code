    class Program
    {
        public static void Main(params string[] args)
        {
            int x, y;
            var prompt = new Prompt();
            prompt.WriteLine("Please enter the point's coordinates in this form (x,y):");
            var savedPos = prompt.GetCursorPosition();
            while (true)
            {
                x = Convert.ToInt32(prompt.Write("(").ReadLine(true, true));
                y = Convert.ToInt32(prompt.Write(",").ReadLine(true));
                prompt.WriteLine(")");
                // do something with x and y
                var again = prompt.Write("More (Y):").ReadLine(true, true);
                if (!again.StartsWith("Y", StringComparison.OrdinalIgnoreCase))
                    break;
                prompt.RestorePosition(savedPos);
            }
        }
    }
