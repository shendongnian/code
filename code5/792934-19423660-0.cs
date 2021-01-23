    if (string.IsNullOrEmpty(tbxAddWord.Text))
        {
            MessageBox.Show("You have entered no characters in the textbox.");
            tbxAddWord.Focus();
            return;
        }
        //if the number of items in the listbox is greater than 29
        else if (lbxUnsortedList.Items.Count > 29)
        {
            MessageBox.Show("You have exceeded the maximum number of words in the list.");
            tbxAddWord.Text = "";
            return;
        }
