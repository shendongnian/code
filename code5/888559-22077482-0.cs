    label4(wordToGuess): DATA
    label5(wordToShow):  *ATA
...
    public void myGuess(char letter)
        {
            string wordToGuess = label4.Text;
            string wordToShow = label5.Text;
            if (wordToShow.Length == 0)
            {
                for (int i = 0; i < wordToGuess.Length; i++)
                    wordToShow += "*";
            }
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == letter || wordToGuess[i] == wordToShow[i])
                    wordToShow = wordToShow.Remove(i,1).Insert(i, Char.ToString(letter));
            }
            label5.Text = wordToShow;
        }
