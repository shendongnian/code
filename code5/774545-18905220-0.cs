    public void ReplaceAll(RichTextBox myRtb, string word, string replacement){
       int i = 0;
       int n = 0;
       int a = replacement.Length - word.Length;
       foreach(Match m in Regex.Matches(myRtb.Text, word)){          
          myRtb.Select(m.Index + i, word.Length);
          i += a;
          myRtb.SelectedText = replacement;
          n++;
       }
       MessageBox.Show("Replaced " + n + " matches!");
    }
