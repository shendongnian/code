    public class ItemComparer : IEqualityComparer<Item>
    {
        public bool Equals(Item x, Item y)
        {
            return (x.Cat == y.Cat) && (x.Name == y.Name);
        }
        public int GetHashCode(Item obj)
        {
            return (obj.Cat.GetHashCode() * 17) + (obj.Name.GetHashCode() * 17);
        }
    }
    public bool AreEqual(IEnumerable<T> set1, IEnumerable<T> set2, 
        IEqualityComparer<T> equalityComparer)
    {
        // Handle cheapest cases
        if (set1 == null && set2 == null)
        {
            return true;
        }
        else if (set1 == null && set2 != null
            || set1 != null && set2 == null)
        {
            return false;
        }
        else if (object.ReferenceEquals(set1, set2))
        {
            return true;
        }
        var hashSet1 = new HashSet<T>(set1, equalityComparer);
        var hashSet2 = new HashSet<T>(set2, equalityComparer);
        // More easy cases
        if (hashSet1.Count != hashSet2.Count)
        {
            return false;
        }
        if (set1.Any(i => !hashSet2.Contains(i))
            || set2.Any(i => !hashSet1.Contains(i)))
        {
            return false;
        }
        return true;
    }
