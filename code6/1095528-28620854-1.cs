    Dictionary<string, string> selectedCharacters = new Dictionary<string, string>();
    
    private void button1_Click(object sender, RoutedEventArgs e)
    {   
        string[] w = SplitWords(MC.Text);
        selectedCharacters.Clear();
    
        foreach (string s in w)
        {
            // Check whether KEY exists  
            if(!selectedCharacters.ContainsKey(s)){
                string fileName = "";
                Items.TryGetValue(s, out fileName);
                selectedCharacters.Add(s, fileName);
            }
        }
    
        foreach (var item in selectedCharacters)
        {
            testBlock.Text += string.Format(item.Key + "   " +
            item.Value + "\n");
         }
     }
    
    static string[] SplitWords(string s)
    {
        return s.Split(','); //It would do the same as regex
    }
