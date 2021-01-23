    public void question()
    {
        for (int i = 1; i <= 10; i++){
            if (questionNr == 1)
            {
                questionLabel.Text = "What is Chuck's full name?";
                ans1.Text = "Charles Irving Bartowski";
                ans2.Text = "Charles Richard Bartowski";
                ans3.Text = "Charles Luke Bartowski";
                ans4.Text = "Zachary Strahovski";
            }
            else if (questionNr == 2)
            {
                questionLabel.Text = "Who/what is Orion?";
                ans1.Text = "Original name of the Intersect";
                ans2.Text = "Alias of a secret mission";
                ans3.Text = "Morgan's Xbox";
                ans4.Text = "Chuck's father";
            }
        }
    }
    public void ans1_Click(object sender, EventArgs e)
    {
        if (questionNr == 1)
        {
            pointCounter++;
            pointsLabel.Text = "Current points:" + pointCounter.ToString();
            questionNr++;
        }
    }
    private void ans2_Click(object sender, EventArgs e)
    {
        if (questionNr == 1)
        {
            questionNr++;
        }
    }
    private void ans3_Click(object sender, EventArgs e)
    {
        if (questionNr == 1)
        {
            questionNr++;
        }
    }
    private void ans4_Click(object sender, EventArgs e)
    {
        if (questionNr == 1)
        {
            questionNr++;
        }
    }
