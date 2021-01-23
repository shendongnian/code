     public DateTime Arrange5Min(DateTime value)
     {
        var stamp = value.timestamp;
        stamp = stamp.AddMinutes(-(stamp.Minute % 5));
        stamp = stamp.AddMilliseconds(-stamp.Millisecond - 1000 * stamp.Second);
        return stamp;
     }
    public int MyGetHashCode(DataRow r)
    {
            unchecked // Overflow is fine, just wrap
        {
           int hash = 17;
           // Suitable nullity checks etc, of course :)
           hash = hash * 23 + r[1].ToString().GetHashCode();
           hash = hash * 23 + r[2].ToString().GetHashCode();
           hash = hash * 23 + r[3].ToString().GetHashCode();
           var stamp = Arrange5Min(Convert.ToDateTime(r[0].ToString()));
           
           hash = hash * 23 + stamp.GetHashCode();
           return hash;
        } 
    }
