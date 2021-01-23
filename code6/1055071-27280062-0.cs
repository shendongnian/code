    class Merchandise: IComparable
    {
        public string MerchandiseName { get; set; }
        public string MerchandiseID { get; set; }
        public string MerchandiseDesc { get; set; }
        // a simple constructor
        public Merchandise(string n, string id, string d)
        { MerchandiseName = n; MerchandiseID = id; MerchandiseDesc = d; }
        // a simple ToString, always good to have around!
        public override string ToString()
        {  return MerchandiseName + " (" + ID + ")";  }
        // the key method that implements IComparable
        public int CompareTo(object o2)
        {
            if (o2 == null) return 1;
            Merchandise m2 = o2 as Merchandise;
            if (m2 != null) return this.ID.CompareTo(m2.MerchandiseID);
            else            throw new ArgumentException("Object is not Merchandise ");
                
        }
