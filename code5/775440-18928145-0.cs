    public class Animal
    {
        public Animal(string fName, string lName)
        {
            this.FName = fName;
            this.LName = lName;
        }
        public string FName {get;set;}
        public string LName {get;set;}
        public string FullName
        {
            get
            { 
                return String.Format("{0} {1}", FName,LName);
            }
        }
    }
           
