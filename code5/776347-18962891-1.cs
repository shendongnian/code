    System.Threading.Timer BarUpdateTimer = new System.Threading.Timer(
        BarUpdate, null, TimeSpan.FromSeconds(10), TimeSpan.Infinite);
    DateTime LastBarUpdate = DateTime.MinValue;
    void BarUpdate(object state)
    {
        ...
    }
