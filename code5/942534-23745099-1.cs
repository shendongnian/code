    int x = 0;
    private void button8_click(object sender, EventArgs e)
    {
       if (x == 0)
        {
        timer1.Start();
        x = 1;
        }
      else if(x == 1)
        {
        timer1.Stop();
        x = 0;
        }
    }
