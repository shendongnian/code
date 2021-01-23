    string Stack = "azersdj8qsdfqzer17";
    string[] digits = Regex.Split(Stack, @"\D+");
    textoutput.Text = "replace";
    textoutput2.Text = "replace";
    textoutput3.Text = "replace";
    foreach (string value in digits)
    {
        if (textoutput.Text == "replace") { 
            textoutput.Text = value;
        } else if (textoutput2.Text == "replace") {
            textoutput2.Text = value;
        } else {
            textoutput3.Text = value;
        }
    }
