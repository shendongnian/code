    public class Person
    {
        private Person leader;
        public Person Leader
        {
            get
            {
                return leader;
            }
            set
            {
                if (Object.Equals(leader, value))
                {
                    return;
                }
                if (leader != null)
                {
                    throw new InvalidOperationException("Leader can be set only once!");
                }
                leader = value;
            }
        }
    }
