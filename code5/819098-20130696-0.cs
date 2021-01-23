    private void timer1_Tick(object sender, EventArgs e)
    {
        paper.Clear(Color.LightSteelBlue);
        DrawBall();
        MoveBall();
        DrawBat(paper);
        if (btnDisplayBricks_Click[0] == true)
        {
            DrawBricks(paper);
        }
    }
    private void btnDisplayBricks_Click(object sender, EventArgs e)
    {
        DrawBricks(paper);
    }
