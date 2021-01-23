    private static string MakePigLatin(string word)
    {
        const string vowels = "AEIOUaeiou";
    
        char let1 = word[0];
        string restLet = word.Substring(1, word.Length - 1);
    
        return vowels.Contains(let1) ? word + "way" : restLet + let1 + "ay";
    }
    private void btnTrans_Click( object sender, EventArgs e )
    {
         var plWords = engWord.Text
                              .Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries)
                              .Select(MakePigLatin);
         latinInput.Text = string.Join(" ", plWords);
         engWord.Clear();    
    }
            
