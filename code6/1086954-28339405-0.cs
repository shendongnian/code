    public override string ToString()
    {
        if (this.Date == DateTime.Now)
            return this.Date.ToString("dd.MM.yyyy HH:MM:SS");
        
        return this.Date.ToString("dd.MMMM.yyyy");
    }
