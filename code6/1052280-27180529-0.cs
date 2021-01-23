    bool[] allButtons = new bool[24];
    private void button_Click(object sender, EventArgs e)
    {
        var indexButton = int.Parse((((Button)sender).Name.Substring(6))) - 1;
        allButtons[indexButton] = true;
        allButtonsClicked();
    }
    private void allButtonsClicked()
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
            finishButton.BackColor = Color.Green;
        }
    }
