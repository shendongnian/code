    public class Animal
    {
        public Animal(string fName, string lName)
        {
            this.FName = fName;
            this.LName = lName;
        }
        public string FName {get;set;}
        public string LName {get;set;}
        public override string ToString()
        {
            return String.Format("{0} {1}", FName,LName);
        }
    }
