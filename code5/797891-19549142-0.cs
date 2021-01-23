    static readonly IList<Color> myColors =
            new[] { Color.Red, Color.Blue, Color.Green, Color.White, Color.Yellow };
    private void btnGelb_Click(object sender, EventArgs e)
    {
        int summe = 0, z;
        lblAnzeige.Text = " ";
        while (summe <= 0)
        {
            z = r.Next(1, 6);
            summe = summe + z;
        }
        lblAnzeige.Text += colors[summe - 1] + "\n";
        lblAnzeige.ForeColor = myColors[Farbe.Next(myColors.Count)];
    }
