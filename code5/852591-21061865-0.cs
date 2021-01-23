     List<string> plWords = new List<string>();         
     // translate each word into pig latin
     foreach (string word in transWord)
     {
             // check for empty TextBox
             try
             {
                 let1 = word.Substring(0, 1);
                 restLet = word.Substring(1, word.Length - 1);
                 position = vokal.IndexOf(let1);
    
                 if (position == -1)
                 {
                     pigLatin = restLet + let1 + "ay";
                 }
                 else
                 {
                     pigLatin = word + "way";
                 }
    
                 plWords.Add(pigLatin);
             }
             catch (System.ArgumentOutOfRangeException)
             {
                 MessageBox.Show("Du måste skriva in ett engelskt ord", "PigLatin",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
     }
     engWord.Clear();    
     latinInput.Text = plWords.Join(" ");
