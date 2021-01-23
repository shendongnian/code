            int[] user31 = new int[53];
            string[] lines = System.IO.File.ReadLines("ratings.txt").Skip(1675).Take(53).ToArray();
            int i = 0;
            foreach (var line in lines)
            {
                user31[i++] = Convert.ToInt32(lines[i]);
            }
