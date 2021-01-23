    public class BidComparer : IComparer<BidDatum> {
	    public int Compare(BidDatum x, BidDatum y) {
		    return (x.Type != y.Type) ? (x.Type.CompareTo(y.Type)) : ((x.Type == "Ask") ? y.Price.CompareTo(x.Price) : x.Price.CompareTo(y.Price));
	    }
    }
