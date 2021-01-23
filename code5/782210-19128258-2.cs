        using System.Collections.Generic;
        class Person
        {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public List<double> Fees { get; set; }
        public Person() 
        { }
        public Person(
            int iD,
            string fName,
            string lName,
            List<double> fees)
        {
            ID = iD;
            FName = fName;
            LName = lName;
            Fees = fees;
        }
    }
