    public Bitmap[] fill()
    {
        List<Bitmap> cr = new List<Bitmap>();
        Card a = new Card();
        Card b = new Card(); 
        Card c= new Card();
        Card d = new Card();
        Bitmap n;
        for (int i = 0; i < 10; i++)
        {
            d.Num++;
            d.Color1 = new SolidBrush(Color.Blue);
            d.Color2 = new SolidBrush(Color.White);
            d = new Card(d.Color1, d.Color2, d.Num);
            n = d.DrawCard();
            cr.Add(n);
        }
        for (int i = 0; i < 10; i++)
        {
            a.Num++;
            d.Color1 = new SolidBrush(Color.Yellow);
            d.Color2 = new SolidBrush(Color.White);
            d = new Card(d.Color1, d.Color2, a.Num);
            n = d.DrawCard();
            cr.Add(n);
        }
        for (int i = 0; i < 10; i++)
        {
            b.Num++;
            d.Color1 = new SolidBrush(Color.Red);
            d.Color2 = new SolidBrush(Color.White);
            d = new Card(d.Color1, d.Color2, b.Num);
            n = d.DrawCard();
            cr.Add(n);
        }
        for (int i = 0; i < 10; i++)
        {
            c.Num++;
            d.Color1 = new SolidBrush(Color.Green); 
            d.Color2 = new SolidBrush(Color.White);
            d = new Card(d.Color1, d.Color2, c.Num);
            n = d.DrawCard();
            cr.Add(n);
        }
        return cr.ToArray();
    }
