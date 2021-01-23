            string[] tableNames = new string[] { "table1", "table2" };
            List<string> fields = new List<string>();
            Regex rgx = new Regex(@"\w+(?=\s?,?)");
            MatchCollection matches = rgx.Matches(textBox1.Text);
            foreach (Match m in matches)
            {
                if (!tableNames.Contains(m.Value))
                {
                    fields.Add(m.Value);
                }
            }
