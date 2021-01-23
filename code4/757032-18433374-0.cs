    public class Person
    {
        public int socialSecurityNr;
        public string name;
        public int age;
        public double heigth;
    
        public Person(int p_socialSecurityNr, string p_name, int? p_age, double? p_heigth)
        {
            this.socialSecurityNr = p_socialSecurityNr; // Can't be null 
            if (p_name != null)
            {
                this.name = p_name;
            }
            if (p_age != null)
            {
                this.age = p_age.Value;
            }
            if (p_heigth != null)
            {
                this.heigth = p_heigth.Value;
            }
        }
    }
