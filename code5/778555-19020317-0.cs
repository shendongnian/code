    public int CompareTo(object other) {
        if(this.GetType() != other.GetType()) {
            return Comparer.Default.Compare(this, other);
        }
        return (this.Hours*60 + this.Minutes).CompareTo(
            ((ErrorAfterObject)other).Hours*60 + ((ErrorAfterObject)other).Minutes);
    }
