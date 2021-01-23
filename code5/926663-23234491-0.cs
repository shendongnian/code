    button1_click(object sender, EventArgs e)
    {
        if (turn == 1)
        {
            gridX.Visibility = visible;
        }
        else
        {
            gridO.Visibility = visible;
        }
        button1.Visibility = hidden;
    }
