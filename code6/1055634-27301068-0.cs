    private bool healing = false;
    public bool Healing
    {
         get { return healing; }
         set
         {
             healing = value;
             if (healing)
                timer.Start();
             else
                timer.Stop();
         }
    }
