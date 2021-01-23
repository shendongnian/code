    for (int a = 1; a <= 10; a++)
    {
        for (int b = 1; b <= 10; b++)
        {
            lblTable.Text += (string.Format("{0} * {1} = {2}\n",
                a.ToString().PadLeft(2),
                b.ToString().PadLeft(2),
                (a * b).ToString().PadLeft(3)));
        }
    }
