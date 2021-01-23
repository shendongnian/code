    private bool buttonClicked = false;
    private void timer1_Tick(object sender, EventArgs e)
    {
        paper.Clear(Color.LightSteelBlue);
        DrawBall();
        MoveBall();
        DrawBat(paper);
        if (buttonClicked)
        {
            DrawBricks(paper);
            // maybe you want to set buttonclicked to false again, but specs are not clear to me
            // buttonClicked = false;
        }
    }
    private void btnDisplayBricks_Click(object sender, EventArgs e)
    {
        DrawBricks(paper);
        buttonClicked = true;
    }
