    public override string ToString()
    {
        if (this.Date.Date == DateTime.Today) // ignore TimeOfDay
            return this.Date.ToString("dd.MM.yyyy HH:MM:SS");
        
        return this.Date.ToString("dd.MMMM.yyyy");
    }
