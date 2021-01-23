    bool clockedIn = false;
    public void button1_Click(object sender, EventArgs e)
    {
        if (!clockedIn)
        {
            // employee just arrived - log arrival time
        }
        else
        {
            // employee leaving - log departure time
        }
        clockedIn = !clockedIn;
    }
