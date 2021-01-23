    public void newword()
    {
        WordList list = new WordList();
        list.Anagrams.Add("Test1");  <-- Add items to list before accessing it
        list.Anagrams.Add("Test2");
        list.Anagrams.Add("Test3");
        Random rnd = new Random();
        int num = rnd.Next(0, list.Anagrams.Count);
        info.Text = "The anagram is " + list.Anagrams[num] +
                     " guess the original word";
    }
