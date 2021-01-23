    public class Foo
    {
        public string Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public override bool Equals(object obj)
        {
            Foo other = obj as Foo;
            if (other == null)
                return false;
            return string.Equals(Year, other.Year) && 
                   string.Equals(Make, other.Make) && 
                   string.Equals(Model, other.Model);
        }
        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Year.GetHashCode();
            hash = (hash * 7) + Make.GetHashCode();
            hash = (hash * 7) + Model.GetHashCode();
            return hash;
        }
    }
