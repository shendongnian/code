    protected void Timer2_Tick(object sender, EventArgs e)
            {
    
                if (timeLeft > 0)
                {
                    // Display the new time left 
                    // by updating the Time Left label.
                    timeLeft = timeLeft - 1;
                    Label1.Text = timeLeft + " seconds";
                }
                else
                {
                    // If the user ran out of time, stop the timer, show 
                    // a MessageBox, and fill in the answers.
                    Timer2.Enabled = false;
                    Label1.Text = "Time's up!";
                    MessageBox.Show("You didn't finish in time.", "Sorry");
    
                    Butnupdate.Enabled = false;
                }
