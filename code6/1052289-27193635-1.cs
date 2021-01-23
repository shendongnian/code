    private void button_Click(object sender, EventArgs e)
    {
        var indexButton = int.Parse((((Button)sender).Name.Substring(6))) - 1;
        allButtons[indexButton] = true;
        if (allButtonsClicked())
        {
            finishButton.BackColor = Color.Green;
        }
    }
