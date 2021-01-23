    if (Double.TryParse(lblAmount.Text, out club1Price))
    {
        club1Total = club1Price * value;
    }
    else
    {
        // the parse failed
        club1Price = 1.25;
        club1Total = club1Price * value;
    }
    
    string totalRoundClub2 = Convert.ToString(Math.Round(club2Total, 2, MidpointRounding.AwayFromZero));
    lblAmount.Text = Convert.ToString(totalRoundClub2);
