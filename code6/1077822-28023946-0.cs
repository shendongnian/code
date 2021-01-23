    DateTime _lastMouseEventTime = DateTime.UtcNow;
    void OnMouseEnter(object sender, MouseEventArgs e)
    {
        DateTime now = DateTime.UtcNow;
        if (now.Subtract(_lastMouseEventTime).TotalSeconds >= 1)
        {
            // do stuff...
        }
        _lastMouseEventTime = now;
    }
