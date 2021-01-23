    public int MyGetHashCode(DataRow r)
    {
            unchecked // Overflow is fine, just wrap
        {
           int hash = 17;
           // Suitable nullity checks etc, of course :)
           hash = hash * 23 + r[1].ToString().GetHashCode();
           hash = hash * 23 + r[2].ToString().GetHashCode();
           hash = hash * 23 + r[3].ToString().GetHashCode();
           var stamp = Convert.ToDateTime(r[0].ToString());
           stamp = stamp.AddMinutes(-(stamp.Minute % 5));
           stamp = stamp.AddMilliseconds(-stamp.Millisecond - 1000 * stamp.Second);
        
           hash = hash * 23 + stamp.GetHashCode();
           return hash;
        } 
    }
