    public class Customer : IComparable<Customer>
    {
        public int CompareTo(Customer other)
        {
            if (other == null) return 1;
            return this.A.CompareTo(other.A);
        }
    }
