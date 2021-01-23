        static void Main(string[] args)
        {
            string reason = null;
            if (!IsPasswordValid(null, ref reason)) Console.WriteLine(reason);
            if (!IsPasswordValid("", ref reason)) Console.WriteLine(reason);
            if (!IsPasswordValid("aaaaaaaa", ref reason)) Console.WriteLine(reason);
            if (!IsPasswordValid("_aaaaaaa", ref reason)) Console.WriteLine(reason);
            if (!IsPasswordValid("aaaaaaa_", ref reason)) Console.WriteLine(reason);
            if (!IsPasswordValid("1aaa!aaa", ref reason)) Console.WriteLine(reason);
            if (!IsPasswordValid("11111111", ref reason)) Console.WriteLine(reason);
            if (!IsPasswordValid("a1a1a1a1", ref reason)) Console.WriteLine(reason);
            if (!IsPasswordValid("a1a1@1a1", ref reason)) Console.WriteLine(reason);
            StringBuilder sb = new StringBuilder();
            sb.Append('a');
            for (int i = 0; i < 1000000; i++) { sb.Append('@'); }
            sb.Append('a');
            sb.Append('1');
            string pass = sb.ToString();
            long ticks = Environment.TickCount;
            if (IsPasswordValid(pass, ref reason)) Console.WriteLine("Valid.");
            long endticks = Environment.TickCount;
            Console.WriteLine("Time elapsed: " + (endticks - ticks));
        }
