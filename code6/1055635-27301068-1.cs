    public bool Healing { get; set; }
    
    public void SetHealingWithTimer(bool status)
    {
         Healing = status;
         if (Healing)
             timer.Start();
         else
             timer.Stop();
    }
