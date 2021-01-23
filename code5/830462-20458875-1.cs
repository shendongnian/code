    var selectedChoice = Enum.GetName(typeof(Choice), choice);
    if (result == "Draw")
        MessageBox.Show(string.Format("It is a draw. Both chose ", selectedChoice);
    else if (result == "Win")
        MessageBox.Show(string.Format("Congratulations! Rock beats ", selectedChoice);
    else if (result == "Lose")
        MessageBox.Show(string.Format("You lose. Paper beats rock ", selectedChoice);
