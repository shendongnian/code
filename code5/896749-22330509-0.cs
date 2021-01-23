            string[] names = new string[] { "Matt", "Joanne", "Robert" };
            Array.Resize(ref names, names.Length + 1);
            names[names.Length - 1] = "Steve";
            // Consider using this instead:
            //List<string> names = new List<string> { "Matt", "Joanne", "Robert" };
            //names.Add("Steve");     // Add a new entry
            //foreach (string i in names)
            //{
            //    richTextBox1.AppendText(i + Environment.NewLine);
            //}
            richTextBox1.Text = String.Join(Environment.NewLine, names);
