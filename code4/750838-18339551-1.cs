    public class TestClassPeter : ITestClass
    {
        private PersonChoice personChoice;
    
        // Default Constructor
        public TestClassPeter()
        {
        }
    
        // Constructor where global personChoice is stored
        public TestClassPeter(PersonChoice personChoice)
        {
            this.personChoice = personChoice;
        }
    
        public string NamePlusLastName(string name)
        {
            return string.Concat(name, " ", "Mc.Cormick");
        }
    
        public int AgePlus20(int age)
        {
            return age + 40;
        }
    
        public DateTime YearYouWillDie(int age)
        {
            return DateTime.Now;
        }
    
        public PersonChoice PersonChoice
        {
            get{return personChoice;}
        }
    }
