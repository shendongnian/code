    private const int TotalSteps = 3;
    private int step;
    private void nextButton1Text()
    {
        switch (step % TotalSteps)
        {
            case 0:
                button1.Text = "Input First Integer";
                break;
            case 1:
                button1.Text = "Input Second Integer";
                break;
            case 2:
                button1.Text = "Input Third Integer";
                break;
        }
        button1.Enabled = step >= TotalSteps;
        step++;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        nextButton1Text();
    }
