    public void Calculate()
    {
        for(int i = 1; i < 5; i++)
        {
            D.ID = i;
            for (int j = 0; j < 5; j++)
            {
                D.X = j;
                D.Y = j;
            }
            MessageBox.Show("ID " + D.ID + " Total Sum" + D.Total);
            D.Total = 0;
        }
    }
