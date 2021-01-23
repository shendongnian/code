    public class Stock {
        public string Name {get; set;}
        public List<int> Values {get; set;}
        public float Price {get; set;}
        public bool Equals(object obj) {
            if (obj == this) return true;
            var other = obj as Stock;
            if (other == null) return false;
            return Name.Equals(other.Name)
                && Price == other.Price
                && Values.SequenceEqual(other.Values);
        }
        public int GetHashCode() {
            return Name.GetHashCode()
                 + Price.GetHashCode
                 + Values.Sum();
        }
    }
