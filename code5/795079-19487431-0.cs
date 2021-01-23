    int current = 0;
    List myFiles = new List()
                    {
                     // Put your multiple images here..
                    “Monkey_Images/img_tablet1.png”,
                    “Monkey_Images/img_tablet2.png”,
                    “Monkey_Images/img_tablet3.png”,
                    “Monkey_Images/img_tablet4.png”,
                    “Monkey_Images/img_tablet5.png”,
                    “Monkey_Images/img_tablet6.png”,
                    “Monkey_Images/img_tablet7.png”
                    };
    DispatcherTimer dtimer = new DispatcherTimer();
    List bmps = new List() { };
    public void MonkeyMovement()
    {
          foreach (string ff in myFiles)
          {
            BitmapImage bmp = new BitmapImage(new Uri(ff, UriKind.Relative));
            bmps.Add(bmp);   // Temporary assign images into bitmapimage list.
          }
          dtimer.Interval = TimeSpan.FromMilliseconds(20);
          dtimer.Tick += new EventHandler(dtimer_Tick);
          dtimer.Start();
    }
    void dtimer_Tick(Object sender, EventArgs e)
    {
         imgLoading.Source = bmps[current];
            current++;
            if (current >= 6)
            {
                current = 0;
            }
    }
