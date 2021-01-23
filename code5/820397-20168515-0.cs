    // Obtain the character index where the user clicks on the control.
    int positionToSearch = richTextBox1.GetCharIndexFromPosition(new Point(e.X, e.Y));
    char currentChar = richTextBox1.Text[positionToSearch];// Get the character the cursor is on.
    string word = currentChar.ToString();// Get a string representation of the character.
    words.Items.Add(word); // Add the current string(character) to our list.
