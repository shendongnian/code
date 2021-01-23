    public class SalesOrder : IEquatable<SalesOrder>
    {
        public int DocNum { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime DocDueDate { get; set; }
        public double DocTotal { get; set; }
        public int LineItemCount { get; set; }
        public string Comments { get; set; }
        public bool Equals(SalesOrder other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(cardCode, other.cardCode) &&
                   string.Equals(cardName, other.cardName) &&
                   docDueDate.Equals(other.docDueDate) &&
                   docTotal.Equals(other.docTotal) && 
                   lineItemCount == other.lineItemCount &&
                   string.Equals(comments, other.comments);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SalesOrder) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (cardCode != null ? cardCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (cardName != null ? cardName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ docDueDate.GetHashCode();
                hashCode = (hashCode*397) ^ docTotal.GetHashCode();
                hashCode = (hashCode*397) ^ lineItemCount;
                hashCode = (hashCode*397) ^ (comments != null ? comments.GetHashCode() : 0);
                return hashCode;
            }
        }
