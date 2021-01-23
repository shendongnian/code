    this.Controls.Add(missile);
    System.Timers.Timer t1 = new System.Timers.Timer();
    t1.Interval = 500;
    t1.Elapsed += (sender, args) => 
    {
      if (missile.Location.Y > 0)
      {
        missile.Location = new Point(missile.Location.X, missile.Location.Y - 5);
      }
    };
    t1.Start();
    
    
