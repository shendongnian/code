    private bool allButtonsClicked()
    {
        const int totalButtons = 23;
        int counter = 0;
        for (int i = 0; i < totalButtons; i++)
        {
            if (allButtons[i])
            {
                counter++;
            }
        }
        if (counter == totalButtons)
        {
            return true;
        }
        return false;
    }
