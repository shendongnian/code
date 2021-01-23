    private int? _hashCode;
    public override int GetHashCode() {
       if (!_hashCode.HasValue)
          _hashCode = Property1.GetHashCode() ^ Property2.GetHashCode() etc... based on whatever you use in your equals method
       return _hashCode.Value;
    }
