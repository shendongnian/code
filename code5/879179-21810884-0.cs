        private static void ShowStar(int p)
        {
            // collecting data. In more complex environments this should be
            // in a separate method, like var lines = collectLines(p)
            var lines = new string[p*2+1];
            var stars = "*";
            for (int i = 0; i <= p; i++)
            {
                lines[i] = lines[p * 2 - i] = stars;
                stars += "*";
            }
            // writing the data. In more complex environments this should be
            // in a separate method, like WriteLines(lines)
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
