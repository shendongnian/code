    Random random = new Random(); 
    private void timer1_Tick(object sender, EventArgs e)
    {
            int X = random.Next(0, 1230); 
            int y = X; 
            label2.Location = new Point(X, 5);
            label3.Location = new Point(X, 5);
            for (int i = 5; i <= 470; i++)
            {
                label2.Location = new Point(y, i);
                label3.Location = new Point(y, i);
                Thread.Sleep(1);
            }
    }
