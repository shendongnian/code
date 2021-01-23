    interface IPerson {
        string Name { get; set; }
        string Age { get; set; }
    }
    public class Person : IPerson {
        public string Name { get; set; }
        public string Age { get; set; }
    }
    public class SupremeBeing : Person
    {
        public string Power { get; set; }
    }
    public class Payroll 
    {
        public void DoSomething(IEnumerable<IPerson> peopleIn)
        {
            //..everyone does this and that 
            IEnumerable<Person> NormalPeople = peopleIn.OfType<Person>();
            if (NormalPeople.Count() > 0) DoSomethingNormalSpecific(NormalPeople);
            IEnumerable<SupremeBeing> SupremeBeings = peopleIn.OfType<SupremeBeing>();
            if (SupremeBeings.Count() > 0) DoSomethingSupremeSpecific(SupremeBeings);
            
        }
        public void DoSomethingNormalSpecific(IEnumerable<Person> normalPeopleIn) 
        {
            // just normal people
        }
        public void DoSomethingSupremeSpecific(IEnumerable<SupremeBeing> supremeBeingsIn)
        {
            // just Supreme Beings
        }
    }
