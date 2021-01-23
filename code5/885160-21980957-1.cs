      private void Rchtxt_TextChanged(object sender, EventArgs e)
            {
                this.CheckKeyword("while", Color.Purple, 0);
                this.CheckKeyword("if", Color.Green, 0);
            }
 
    private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.Rchtxt.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.Rchtxt.SelectionStart;
    
                while ((index = this.Rchtxt.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.Rchtxt.Select((index + startIndex), word.Length);
                    this.Rchtxt.SelectionColor = color;
                    this.Rchtxt.Select(selectStart, 0);
                    this.Rchtxt.SelectionColor = Color.Black;
                }
            }
        }
