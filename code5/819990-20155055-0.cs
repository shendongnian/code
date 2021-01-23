    string phrase = "I’m a member of the Imperial Senate on a diplomatic mission to Alderaan.";
    int selectedPosition = 41;
    char boldedChar = 'a';
    string beforeSelected = phrase.Substring(selectedPosition).Trim();
    int testedIndex = beforeSelected.LastIndexOf(' ') + 1;
    if (phrase[testedIndex] == boldedChar)
    {
        phrase = phrase.Substring(0, testedIndex - 1) + 
                 "<strong> " + boldedChar + "</strong>" + 
                 phrase.Substring(selectedPosition);
    }
