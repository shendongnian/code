    public class PersonAndTime
    {
        public PersonAndTime(Person person, TimePeriod timePeriod)
        {
            Person = person;
            TimePeriod = timePeriod;
        } 
        public Person Person{ get; private set; }
        public TimePeriod TimePeriod {get; private set; }
    }
