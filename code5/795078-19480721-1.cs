    const float MAXDELAY = 0.5f; // seconds
    DateTime previousClick;
    bool WasDoubleClick()
    {
       return WasMouseLeftClick() // We have at least one click, and
           && (DateTime.Now - previousClick).TotalSeconds < MAXDELAY;
    }
