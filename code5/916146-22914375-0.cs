    private void ciz()
    {
        int beklemeSuresi = 1000;//1000 = 1sec
        for (int i = 0; i < 15; i++)
        {
            if (g != null)
            {
                g.Clear(Color.AliceBlue);
            }
            solLCiz(100, 100 + i * 20, yon);
            Application.DoEvents();
            Thread.Sleep(beklemeSuresi);
        }
    }
