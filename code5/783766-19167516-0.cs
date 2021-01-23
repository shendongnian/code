    public class SelectListItem : IEquatable<SelectListItem>
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool Equals(SelectListItem other)
        {
            if (other == null)
            {
                return false;
            }
            return Value == other.Value && Text == other.Text;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                if (Value != null)
                {
                    hash = hash * 23 + Value.GetHashCode();
                }
                if (Text != null)
                {
                    hash = hash * 23 + Text.GetHashCode();
                }
                
                return hash;
            }
        }
    }
