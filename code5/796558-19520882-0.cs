    var filter = (from r in _DocksContext.MASTER_DOCKS
              where r.STATE.Equals("TX")
              select r).Distinct().ToList();
    // generated classes are partial, so you can extend them in a separate file
    public partial class MASTER_DOCKS
    {
        // the dropdown uses the ToString method to show the object
        public override string ToString()
        {
            return string.Format("{0} ({1})", WTWY_NAME, ID);
        }
    }
