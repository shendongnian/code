    internal class MagicClass
    {
        public string FirstAttribute { get; set; }
        public string SecondAttribute { get; set; }
        public string ThirdAttribute { get; set; }
        public string FourthAttribute { get; set; }
        public string FifthAttribute { get; set; }
        private string[] AllProperties//Array of all properties
        {
            get
            {
                return new[]
                {
                    FirstAttribute,
                    SecondAttribute,
                    ThirdAttribute,
                    FourthAttribute,
                    FifthAttribute
                };
            }
        }
        protected bool Equals(MagicClass other)
        {
            var thisProps = this.AllProperties;
            var otherProps = other.AllProperties;
            return thisProps.SequenceEqual(otherProps);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MagicClass) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var thisProps = this.AllProperties;
                int hashCode = 0;
                foreach (var prop in thisProps)
                {
                    hashCode = (hashCode * 397) ^ (prop != null ? prop.GetHashCode() : 0);
                }
                return hashCode;
            }
        }
    }
