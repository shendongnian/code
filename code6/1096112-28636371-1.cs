        private void button1_Click(object sender, EventArgs e)
        {
            List<List<KeyValuePair<string, string>>> list = new List<List<KeyValuePair<string, string>>>();
            list.Add(new List<KeyValuePair<string, string>>());
            list[0].Add(new KeyValuePair<string, string>("Category 1", "Value A"));
            list[0].Add(new KeyValuePair<string, string>("Category 1", "Value B"));
            list.Add(new List<KeyValuePair<string, string>>());
            list[1].Add(new KeyValuePair<string, string>("Category 2", "Value C"));
            list[1].Add(new KeyValuePair<string, string>("Category 2", "Value D"));
            list.Add(new List<KeyValuePair<string, string>>());
            list[2].Add(new KeyValuePair<string, string>("Category 3", "Value E"));
            List<List<KeyValuePair<string, string>>> sortedList = new List<List<KeyValuePair<string, string>>>();
            permutation(list, 0, new List<KeyValuePair<string, string>>());
        }
        private void permutation( List<List<KeyValuePair<string, string>>> options, int srcPos, List<KeyValuePair<string, string>> result)
        {
            if (result.Count == options.Count)
                WriteOne(result);
            else
            {
                foreach (KeyValuePair<string, string> opt in options[srcPos])
                {
                    List<KeyValuePair<string, string>> theClone = new List<KeyValuePair<string, string>>(result); 
                    theClone.Add(opt); 
                    permutation(options, srcPos + 1, theClone);
                }
            }
        }
        private void WriteOne(List<KeyValuePair<string, string>> OneResult)
        {
            StringBuilder line = new StringBuilder(80);
            foreach (KeyValuePair<string, string> item in OneResult)
            {
                line.Append("[");
                line.Append(item.Key);
                line.Append(",");
                line.Append(item.Value);
                line.Append("] | ");
            }
            line.Remove(line.Length - 3, 3); // Trim the extra " | "
            line.AppendLine();
            textBox1.AppendText(line.ToString());
        }
