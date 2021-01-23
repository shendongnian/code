    private void TimerClick_Tick(object sender, EventArgs e)
    {
        FirstClickedBox.ForeColor = Color.Transparent;
        SecondClickedBox.ForeColor = Color.Transparent;
        FirstClickedBox = null;
        SecondClickedBox = null;
    }
