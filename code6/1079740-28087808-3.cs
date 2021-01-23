    class SequenceComparer<T>:IEqualityComparer<IEnumerable<T>>
    {
    	public bool Equals(IEnumerable<T> left, IEnumerable<T> right)
    	{
    		return left.OrderBy(x => x).SequenceEqual(right.OrderBy(x => x));
    	}
    	public int GetHashCode(IEnumerable<T> item)
    	{
            //no need to sort because XOR is commutative
            return item.Aggregate(0, (acc, val) => val.GetHashCode() ^ acc);
    	}
    }
