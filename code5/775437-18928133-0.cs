    public class Animal
    {
        public string Fullname {get; set;}
        public Animal(string Fname, string Lname)
        {
            if (Fname == "Jack" | Lname == "Ramp")
            {
                FullName = Fname + " " + Lname;
            }
    }
