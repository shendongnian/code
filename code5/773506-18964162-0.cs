    public static string match;
    
        public static string ReadAllText(string path)
        {
            using (var r = new System.IO.StreamReader(path))
            {
                return r.ReadToEnd();
            }
    
    
        }
    
        private string Wireless(String path, String searchText)
        {
            string regex = @"(?i)(?<=" + searchText + @"\s*=\s*)\d+";
            match = Regex.Match(ReadAllText(path), regex).Value;
            label1.Text = match;
            return match;
    
    
        }
        private string Cradle(String path, String searchText)
        {
            string regex = @"(?i)(?<=" + searchText + @"\s*=\s*)\d+";
            match = Regex.Match(ReadAllText(path), regex).Value;
            label2.Text = match;
            return match;
        }
    
    
    
    
        private void button1_Click(object sender, EventArgs e)
        {
         Wireless(@"\Storage Card\changelog.txt","Wireless");
         Cradle(@"\Storage Card\changelog.txt", "Cradle");
    
        }
