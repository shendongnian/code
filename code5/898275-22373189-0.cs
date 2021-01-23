    public class Complex
    {
        public string Prop1 { get; set; }
        public int Prop2 { get; set; }
        public Complex Prop3 { get; set; }
        public override bool Equals(object obj)
        {
            Complex c2 = obj as Complex;
            if (obj == null) return false;
            return Prop1 == c2.Prop1 && Prop2 == c2.Prop2;
        }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + Prop1.GetHashCode();
                hash = hash * 23 + Prop2;
                return hash;
            }
        }
    }
     
