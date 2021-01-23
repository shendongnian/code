        RichTextBox rtb = new RichTextBox();
        public void Main() //where you are putting your stuff to check
        {
            if (rtb.Text.Substring(0, 10) == "ALTER TABLE" && rtb.Text.Contains("USER1"))
            {
                rtb.Text = Remove(rtb.Text, "\"USER1\".");
            }
        }
        public string Remove(string statement, string toRemove)
        {
            statement = statement.Remove(statement.IndexOf(toRemove), statement.IndexOf(toRemove) + toRemove.Length - 1);
            return statement;
        }
