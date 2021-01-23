    // TODO: Implement IComparable<DatedID> as well :)
    int IComparable.CompareTo(object obj)
    {
        var other = (DatedID)obj;
        int dateComparison = other.Added.CompareTo(this.Added);
        return dateComparison != 0
            ? dateComparison
            : _ID.CompareTo(other._ID);
    }
