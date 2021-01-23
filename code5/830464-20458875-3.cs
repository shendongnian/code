    var selectedChoice = Enum.GetName(typeof(Choice), choice);
    var beatsChoice = selectedChoice == Choice.Rock ? Choice.Scissor
                        : (selectedChoice == Choice.Paper ? Choice.Rock : Choice.Paper);
    if (result == "Draw")
        MessageBox.Show(string.Concat("It is a draw. Both chose ", selectedChoice);
    else if (result == "Win")
        MessageBox.Show(string.Concat("Congratulations! ", selectedChoice, " beats ", beatsChoice);
    else if (result == "Lose")
        MessageBox.Show(string.Concat("You lose. ", selectedChoice, " beats ", beatsChoice);
