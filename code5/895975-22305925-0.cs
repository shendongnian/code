    private void  txt_TextChanged(object sender, EventArgs e)
            {
                this.CheckKeyword("passed", Color.Purple, 0);
                this.CheckKeyword("failed", Color.Green, 0);
            }
    private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.txt.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.Rchtxt.SelectionStart;
    
                while ((index = this.txt.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.txt.Select((index + startIndex), word.Length);
                    this.txt.SelectionColor = color;
                    this.txt.Select(selectStart, 0);
                    this.txt.SelectionColor = Color.Black;
                }
            }
        }
