    public override int GetHashCode()
    {
        var visitKeyHash = this.VisitKey == null ?
            251 : this.VisitKey.GetHashCode();
        var timeHash = this.Time.Year + this.Time.Month + this.Time.Day +
            this.Time.Hour + this.Time.Minute;
    
        return ((visitKeyHash * 251) + timeHash);
    }
    public override bool Equals(object obj)
    {
        KnownMessage message = obj as message;
        //Two quick tests before we start doing all the math.
        if(message == null)
            return false;
        if(Object.ReferenceEquals(this, obj))
            return true;
        return this.VisitKey.Equals(message.VisitKey) &&
               this.time.Year.Equals(message.Time.Year) &&
               this.time.Year.Equals(message.Time.Month) &&
               this.time.Year.Equals(message.Time.Day) &&
               this.time.Year.Equals(message.Time.Hour) &&
               this.time.Year.Equals(message.Time.Minute) 
    }
