    private static readonly Dictionary<string, Frequency> _list = 
        new Dictionary<string, Frequency>();
    public static bool Contains(string key)
    {
        return _list.Any(x => x.Key == key);
    }
    public static bool operator !=(Frequency a, Frequency b)
    {
        return (!a.Equals(b));
    }
    public static bool operator ==(Frequency a, Frequency b)
    {
        return (a.Equals(b));
    }
	public static implicit operator Frequency(string value)
    {
        if (value == null || value.Trim().Length == 0) return Frequency.Null;
        if (Contains(value))
            return _list[value];
        else
            throw new InvalidCastException(string.Format("Frequency.{0} not found.", value));
    }
    public static implicit operator String(Frequency item)
    {
        return item.Value;
    }
    public static readonly Frequency Null = new Frequency("");
	public static readonly Frequency Annually = new Frequency("Annually");
	public static readonly Frequency Fortnightly = new Frequency("Fortnightly");
	public static readonly Frequency FourWeekly = new Frequency("FourWeekly");
	public static readonly Frequency HalfYearly = new Frequency("HalfYearly");
	public static readonly Frequency Monthly = new Frequency("Monthly");
	public static readonly Frequency Quarterly = new Frequency("Quarterly");
