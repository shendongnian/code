    char[] charArray = new char[] { 'a', 'e', 'i', 'o', 'u' };
    string line = "bbcccaaaeeiiiioouu";
    
    var VowelCounts = new Dictionary<char, int>();
    
    foreach(var Vowel in charArray)
    {
    	VowelCounts.Add(Vowel, line.Count(CharInString => Vowel == CharInString));
    }
    
    var ConsonantCounts = new Dictionary<char, int>();
    
    foreach(var Consonant in line.Where(CharInString => !charArray.Contains(CharInString)).Distinct())
    {
    	ConsonantCounts.Add(Consonant, line.Count(CharInString => Consonant == CharInString));
    }
    		
    KeyValuePair<char, int> MostUsedVowel = VowelCounts.OrderBy(Entry => Entry.Value).FirstOrDefault();
    KeyValuePair<char, int> MostUsedConsonant = ConsonantCounts.OrderBy(Entry => Entry.Value).FirstOrDefault();
    
    string Output1 = String.Format("The Vowel '{0}' was used {1} times", MostUsedVowel.Key, MostUsedVowel.Value);
    string Output2 = String.Format("The Consonant '{0}' was used {1} times", MostUsedConsonant.Key, MostUsedConsonant.Value);
    
    MessageBox.Show(Output1);
    MessageBox.Show(Output2);
