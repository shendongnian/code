    Random random = new Random();
    //This is our class level variable
    int correctAnswer;
    private void Init()
    {
        correctAnswer = random.Next(1, 6);
    }
    private bool UserSelectedRandomButton()
    {
        if (radioButton1.Checked == true)
            return (correctAnswer == 1);
        if (radioButton2.Checked == true)
            return (correctAnswer == 2);
        if (radioButton3.Checked == true)
            return (correctAnswer == 3);
        if (radioButton4.Checked == true)
            return (correctAnswer == 4);
        if (radioButton5.Checked == true)
            return (correctAnswer == 5);
        return false;
    }
    private void buttonsubmit_Click(object sender, EventArgs e)
    {
        radioButton1.Enabled = false;
        radioButton2.Enabled = false;
        radioButton3.Enabled = false;
        radioButton4.Enabled = false;
        radioButton5.Enabled = false;
        if (UserSelectedRandomButton() == true)
        {
            labelOutput.Text = "You are correct!";
        }
        else
        {
            labelOutput.Text = (" Sorry, the correct answer is" + " " + correctAnswer);//now working :)
        }
        correctAnswer = random.Next(1, 6);
    }
