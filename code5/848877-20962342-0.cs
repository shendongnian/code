    for (int j = 0; j < statsBonus.GetLength(0); j++)
    {
        int sum = 0;
        for (int i = 0; i < statsBonus.GetLength(1); i++)
        {
            sum+= Int32.Parse(statsBonus[j,i].Text);
        }
        totalsBefore[j].Text = sum.ToString();
    }
