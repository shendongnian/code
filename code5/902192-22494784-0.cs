        private void btn_proceed_Click(object sender, EventArgs e)
        {
            // This dictionary contains indices of rows we need to replace.
            Dictionary<int, int> replaceable = new Dictionary<int, int>();
            replaceable.Add(4, 1);
            replaceable.Add(7, 5);
            replaceable.Add(13, 11);
            string input = String.Empty;
            OpenFileDialog pfdg = new OpenFileDialog();
            if (pfdg.ShowDialog() == DialogResult.OK)
            {
                input = pfdg.FileName;
            }
            // I placed the result into the another file called result.txt. You can use output path as same as input to overwrite the file.
            ReplaceLines(replaceable, input, @"C:\Users\Wallstrider\Documents\Visual Studio 2010\Projects\result.txt");
        }
        /// <summary>
        /// Replaces lines of the file depends on 9th item is exist.
        /// </summary>
        /// <param name="replaceable">Rows incides to replace.</param>
        /// <param name="input_path">Path to the input file.</param>
        /// <param name="output_path">Path to the output file.</param>
        private void ReplaceLines(Dictionary<int, int> replaceable, string input_path, string output_path)
        {
            if (File.Exists(input_path))
            {
                string file;
                file = new StreamReader(input_path).ReadToEnd();
                string[] lines = file.Split(new char[] { '\n' });
                List<string[]> split_data = new List<string[]>();
                for (int i = 0; i < lines.Length; i++)
                    split_data.Add(lines[i].Split(','));
                List<int> allowed_for_replace_indices = new List<int>();
                List<int> not_allowed_for_replace_indices = new List<int>();
                // Check if the row has the value of 9th item then we are allowed to replace rows.
                for (int i = 1; i < split_data.Count; i++)
                {
                    if (split_data[i][9] != String.Empty)
                        allowed_for_replace_indices.Add(i);
                    else
                        not_allowed_for_replace_indices.Add(i);
                }
                List<int> rows_replaced = new List<int>();
                List<int> rows_not_replaced = new List<int>();
                // Loop through our replaceable indices dictionary.
                for (int i = 0; i < replaceable.Count; i++)
                {
                    int key = replaceable.ElementAt(i).Key;
                    int value = replaceable.ElementAt(i).Value;
                    // if both rows have 9th item then we can start replacement.
                    if (allowed_for_replace_indices.Contains(key) && allowed_for_replace_indices.Contains(value))
                    {
                        string temp = lines[value];
                        lines[value] = lines[key];
                        lines[key] = temp;
                        rows_replaced.Add(key);
                        rows_replaced.Add(value);
                    }
                    else
                    {
                        rows_not_replaced.Add(key);
                        rows_not_replaced.Add(value);
                    }
                }
                using (StreamWriter sw = new StreamWriter(output_path))
                {
                    for (int i = 0; i < lines.Length; i++)
                        sw.WriteLine(lines[i]);
                    sw.Flush();
                    sw.Close();
                }
                MessageBox.Show("Rows replaced: " + String.Join("; ", rows_replaced.ToArray()) + " .\nRows not replaced: " + String.Join("; ", rows_not_replaced.ToArray()) + ".\nComplete.");
            }
        }
