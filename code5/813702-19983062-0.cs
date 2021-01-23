    public class QTextBoxEx : QTextBox
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // shortcut to search bar
            if (keyData == (Keys.Control | Keys.Back))
            {
                // 1st scenario: some text is already selected. 
                // In this case, delete only selected text. 
                if (SelectedText != "")
                {
                    int selStart = SelectionStart;
                    Text = Text.Substring(0, selStart) + 
                        Text.Substring(selStart + SelectedText.Length);
                    SelectionStart = selStart;
                    return true;
                }
 
                // 2nd scenario: delete word. 
                // 2 steps - delete "junk" and delete word.
 
                // a) delete "junk" - non text/number characters until 
                // one letter/number is found
                for (int i = this.SelectionStart - 1; i >= 0; i--)
                {
                    if (char.IsLetterOrDigit(Text, i) == false)
                    {
                        Text = Text.Remove(i, 1);
                        SelectionStart = i;
                    }
                    else
                    {
                        break;
                    }
                }
 
                // delete word
                for (int i = this.SelectionStart - 1; i >= 0; i--)
                {
                    if (char.IsLetterOrDigit(Text, i))
                    {
                        Text = Text.Remove(i, 1);
                        SelectionStart = i;
                    }
                    else
                    {
                        break;
                    }
                }
                return true;
            }
 
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
