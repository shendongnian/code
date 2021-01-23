        protected bool Equals(Money other)
        {
            return amount == other.amount && string.Equals(currency, 
                                              other.currency);
                                              //maybe you want this extra param?
                                              //StringComparison.InvariantCulture)
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as Money;
            return other != null && Equals(other);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (amount * 997) ^ currency.GetHashCode();
            }
        }
        public static bool operator ==(Money left, Money right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(Money left, Money right)
        {
            return !Equals(left, right);
        }
