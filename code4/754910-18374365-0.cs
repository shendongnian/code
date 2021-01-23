        string punctuations = " ,.;!?'\")]}";
        //This saves your words with their corresponding definitions/details
        Dictionary<string, string> dict = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
        ToolTip tt = new ToolTip();
        string currentShownWord;
        int lineBreakIndex = 60;
        //MouseMove event handler for your richTextBox1
        private void richTextBox1_MouseMove(object sender, MouseEventArgs e){
            if (richTextBox1.TextLength == 0) return;
            int i = richTextBox1.GetCharIndexFromPosition(e.Location);            
            int m = i, n = i;
            while (m>-1&&!punctuations.Contains(richTextBox1.Text[m])) m--;            
            m++;
            while (n<richTextBox1.TextLength&&!punctuations.Contains(richTextBox1.Text[n])) n++;
            if (n > m){
                string word = richTextBox1.Text.Substring(m, n - m);
                if (dict.ContainsKey(word)){
                    if (currentShownWord != word){
                        tt.ToolTipTitle = word;
                        tt.Show(dict[word], richTextBox1, e.X, e.Y + 10);
                        currentShownWord = word;
                    }
                }
                else{
                    tt.Hide(richTextBox1);
                    currentShownWord = "";
                }
            }
        }
        //This will get the entry text with lines broken.
        private string GetEntryText(string key){
            string s = dict[key];
            int lastLineEnd = lineBreakIndex;
            for (int i = lastLineEnd; i < s.Length; i += lineBreakIndex)
            {
                while (s[i] != ' '){
                    if (--i < 0) break;                    
                }
                i++;
                s = s.Insert(i, "\n");
                lastLineEnd = i+1;
            }
            return s;
        }
        //MouseLeave event handler for your richTextBox1
        private void richTextBox1_MouseLeave(object sender, EventArgs e){
            tt.Hide(richTextBox1);
            currentShownWord = "";
        }
        //Here are some sample words with definitions:
        dict.Add("world", "- World is a common name for the whole of human civilization, specifically human experience, history, or the human condition in general, worldwide, i.e. anywhere on Earth.");
        dict.Add("geek", "- A person who is single-minded or accomplished in scientific or technical pursuits but is felt to be socially inept");
