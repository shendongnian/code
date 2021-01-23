        RichTextBox rtb = new RichTextBox();
        public void Main() //where you are putting your stuff to check
        {
           foreach(string line in rtb.Text.Split('\n'))
             if (line.Substring(0, 10) == "ALTER TABLE" && line.Contains("USER1"))
             {
                line= Remove(line, "\"USER1\".");
             }
        }
        public string Remove(string statement, string toRemove)
        {
            statement = statement.Remove(statement.IndexOf(toRemove), statement.IndexOf(toRemove) + toRemove.Length - 1);
            return statement;
        }
