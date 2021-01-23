    public class product : IEquatable<product>
    {
        public int idProduct { get; set; }
        
        // List<product>.Contains will call IEquatable<product>.Equals if available.
        public bool Equals(product other)
        {
            return ReferenceEquals(other, this) || other.idProduct == this.idProduct;
        }
        
        // Note: you should still override object.Equals.
        public override bool Equals(object other)
        {
            return this.Equals(other as product);
        }
    }
