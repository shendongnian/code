            string[] str = new String[rng.Count];
            int i = 0;
            foreach (Excel.Range cell in rng.Cells)
            {
                str[i] = cell.Value.ToString();
                i++;
            }
            for (int j = 0; j < str.Length; j++)
                Console.WriteLine(str[j]);
