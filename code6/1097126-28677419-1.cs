    public class Person {
        public Person(string name, string hairColor) {
            Name = name;
            HairColor = hairColor;
        }
        public string Name { get; set; }
        public string HairColor { get; set; }
        public override string ToString() {
            return Name + " (" + HairColor + ")";
        }
    }
    
