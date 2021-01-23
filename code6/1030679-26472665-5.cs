    internal sealed class Element : IEquatable<Element>
    {
        private readonly int id;
        public int Id { get { return id; } }
    
        public Element(int id)
        {
            this.id = id;
        }
    
        public static implicit operator Element(int d)  
        {
            return new Element(d);
        }
    
        public static bool operator ==(Element e1, Element e2)
        {
            if (object.ReferenceEquals(e1, e2))
            {
                return true; 
            }
            if (object.ReferenceEquals(e1, null) ||
                object.ReferenceEquals(e2, null))
            {
                return false; 
            }
            return e1.id == e2.id;
        }
    
        public static bool operator !=(Element e1, Element e2)
        {
            // Delegate...
            return !(e1 == e2);
        }
        public override bool Equals(Element other)
        {
            // Or return this == other
            return other != null && id == other.id;
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(object obj)
        {
            // Delegate...
            return obj as other;
        }
    }
