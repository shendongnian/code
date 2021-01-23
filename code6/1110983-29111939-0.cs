    if(bigAlienWasVisible && picBigAlien1.Visible == false)
    {
        ScoreNum = ScoreNum + 10;
        bigAlienWasVisible = false;
        ScoreBox1.Text = ScoreNum.ToString();
    }
