    char[] charArray = new char[] { 'a', 'e', 'i', 'o', 'u' };
    string line = "bbcccaaaeeiiiioouu";
    
    var vowelCounts = new Dictionary<char, int>();
    
    foreach(var vowel in charArray)
    {
    	vowelCounts.Add(vowel, line.Count(charInString => vowel == charInString));
    }
    
    var consonantCounts = new Dictionary<char, int>();
    
    foreach(var consonant in line.Where(charInString => !charArray.Contains(charInString)).Distinct())
    {
    	consonantCounts.Add(consonant, line.Count(charInString => consonant == charInString));
    }
    		
    KeyValuePair<char, int> mostUsedVowel = vowelCounts.OrderBy(Entry => Entry.Value).FirstOrDefault();
    KeyValuePair<char, int> mostUsedConsonant = consonantCounts.OrderBy(Entry => Entry.Value).FirstOrDefault();
    
    string output1 = String.Format("The Vowel '{0}' was used {1} times", mostUsedVowel.Key, mostUsedVowel.Value);
    string output2 = String.Format("The Consonant '{0}' was used {1} times", mostUsedConsonant.Key, mostUsedConsonant.Value);
    
    MessageBox.Show(output1);
    MessageBox.Show(output2);
