    private DateTime _lastWrite = DateTime.Now;
    private TimeSpan _delay = TimeSpan.FromMilliseconds(100);
    public void ComputerDrawCard() {
        var now = DateTime.Now;
        if (now - _lastWrite < _delay)
            return;
        _lastWrite = now;
        draw card...
    }
