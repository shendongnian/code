    private void clearInputHandler(object sender, TextChangedEventArgs e) {
        int oldIndex = myInput.CaretIndex;
        string oldValue = myInput.Text;
        string validInput = Regex.Replace(myInput.Text, "[^A-Za-z0-9]", "");
        myInput.Text = validInput;
        
        if(!oldValue.Equals(validInput)) {
            myInput.CaretIndex = index - 1;
        }
    }
