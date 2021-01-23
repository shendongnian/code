    public int selectedFrameOffset
    {
        get
        {
            switch(PlayerHealth)
            {
               case 3: return 0;
               case 2: return 30;
               case 1: return 60;
               // etc
               default:
                    throw new ArgumentException();
            }
        }
    }
