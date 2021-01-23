    public class A
    {
        public string Value1 { get; set; }
        public int Value2 { get; set; }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = (hash * 23) + 
                    StringComparer.Ordinal.GetHashCode(this.Value1);
                hash = (hash * 23) + this.Value2;
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            var a = obj as A;
            if (a == null)
            {
                return false;
            }
            if (a.Value2 != this.Value2)
            {
                return false;
            }
            return StringComparer.Ordinal.Equals(
                a.Value1,
                this.Value1);
        }
    }
