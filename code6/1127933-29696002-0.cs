        private List<Attributes> LoadCsv()
        {
            string filename = @"C:\Desktop\demo.csv";
            // Get the file's text.
            string whole_file = System.IO.File.ReadAllText(filename);
            // Split into lines.
            whole_file = whole_file.Replace('\n', '\r');
            string[] lines = whole_file.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);
            // See how many rows and columns there are.
            int num_rows = lines.Length;
            int num_cols = lines[0].Split(';').Length;
            // Allocate the data array.
            string[,] values = new string[num_rows, num_cols];
            // Load the array.
            for (int r = 0; r < num_rows; r++)
            {
                string[] line_r = lines[r].Split(';');
                for (int c = 0; c < num_cols; c++)
                {
                    values[r, c] = line_r[c];
                }
            }
            var attr = new List<Attributes>();
            for (var r = 0; r < num_rows; r++)
            {
                if (r == 0)
                {
                    for (var c = 0; c < num_cols; c++)
                    {
                        attr.Add(new Attributes());
                        attr[c].Name = values[r, c];
                        attr[c].Value = new List<String>();
                    }
                }
                else
                {
                    for (var b = 0; b < num_cols; b++)
                    {
                        var input = values[r, b];
                        attr[b].Value.Add(input);
                    }
                }
            }
            // Return the values.
            return attr;
        }
