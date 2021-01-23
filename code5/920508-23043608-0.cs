    public void Assign(int value)
    {
        this.Value = value;
        Tracker.Track(this.Name, ...);
    }
