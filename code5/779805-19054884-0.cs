    string Stack = "azersdj8qsdfqzer17";
    string[] digits = Regex.Split(Stack, @"\D+");
    textoutput.Text = "replace";
    textoutput2.Text = "replace";
    foreach (string value in digits)
    {
        if (textoutput.Text == "replace") { 
            textoutput.Text = value;
        } else {
            textoutput2.Text = value;
        }
    }
