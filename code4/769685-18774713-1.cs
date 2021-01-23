        string s = "How do I do this?              a";//Just for example,i've added a 'a' at the end.
        int index = s.Length - 1;//Get last Char index.
        if (index > 0)//If index exists.
        {
            if (s[index] == ' ')//If the character at 'index' is a space.
            {
                MessageBox.Show("Its a space.");
            }
            else if (char.IsLetter(s[index]))//If the character at 'index' is a letter.
            {
                MessageBox.Show("Its a letter.");
            }
            else if(char.IsDigit(s[index]))//If the character at 'index' is a digit.
            {
                MessageBox.Show("Its a digit.");
            }
        }
