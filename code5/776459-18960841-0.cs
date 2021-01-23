    public class Item {
        public long Id { get; set; }
        public string Number { get; set; }
        public override bool Equals(object obj) {
            if (obj == this) return true;
            var other = obj as Item;
            if (other == null) return false;
            return Id == other.Id;
        }
        public override int GetHashCode() {
            return Id.GetHashCode();
        }
    }
