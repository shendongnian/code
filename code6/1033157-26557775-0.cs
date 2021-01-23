    private int step = 1;
    private void setButton1Text()
    {
        switch (step)
        {
            case 1:
                button1.Text = "Input First Integer";
                break;
            case 2:
                button1.Text = "Input Second Integer";
                break;
            case 3:
                button1.Text = "Input Third Integer";
                break;
            case 4:
                button1.Enabled = false;
                button1.Text = "Input First Integer";
                step = 1;
                break;
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        step++;
        setButton1Text();
    }
