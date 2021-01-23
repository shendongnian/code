    int questionNum = 0;
    Random rand = new Random();
    int numOfQuestionsInTheGame = 100; // this is the number of all your questions
    private void Next_Click(object sender, System.EventArgs e)
    {
        Score++;
        if (questionNum < 10)
        {
            loadquestion(rand.Next(0, numOfQuestionsInTheGame));
        }
        else
        {
            MessageBox.Show("You have finished!" + "Score is: " + Score);
        }
        questionNum++;
    }
