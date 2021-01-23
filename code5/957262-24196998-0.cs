    if (userNumber == selectedNumber)
    {
        userMSGLabel.Text = "You guessed the correct number. Program is exiting";
        userMSGLabel.BackColor = Color.LightGreen;
        Application.DoEvents();
        System.Threading.Thread.Sleep(2000);
        Environment.Exit(-1);
    }
