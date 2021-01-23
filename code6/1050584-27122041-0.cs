    private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        listboxWords1.Items.Clear();
    
        if (searchBox.Text.Length > 0)
        {
            trie.Matcher.ResetMatch();//Reset the match
            foreach (char c in searchBox.Text)
                trie.Matcher.NextMatch(c); //Start the match from beginning 
            foundWords = trie.Matcher.GetPrefixMatches(); //foundWords is List<string>
            for (int i = foundWords.Count - 1; i > 0 ; i--)
            {
                listboxWords1.Items.Add(foundWords[i]);
            }
    
            foundWords = null;
            isFoundExact = trie.Matcher.IsExactMatch();
            if (isFoundExact)
                listboxWords1.Items.Add(trie.Matcher.GetExactMatch());
        }
        else
        {
            foundWords = null;
            trie.Matcher.ResetMatch();    
        }
    }
