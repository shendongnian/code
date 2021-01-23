    public class Customer : IComparable<Customer>
    {
        public int CompareTo(Customer other)
        {
            if (other == null) return 0;
            return other.A.Compare(this.A);
        }
    }
