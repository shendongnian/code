    public abstract class PersonBase
        {
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
    
            public PersonBase(string name, DateTime bd)
            {
                this.Name = name;
                this.BirthDate = bd;
            }
    
            public int CalculateAge()
            {
                return DateTime.Now.Year - BirthDate.Year;
            }
    
            public abstract string HealthRecord { get; set; }
    
            public abstract string DisplayData();
        }
    
        public class TeenagerPerson : PersonBase
        {
            public PersonBase BestFriendForever { get; set; }
            public override string HealthRecord { get; set; }
            public TeenagerPerson(string name, DateTime bd)
                : base(name, bd)
            {
            }
    
            public override string DisplayData()
            {
                return string.Format("Name:{0}  Age:{1}  Health record:{2}  BFF:{3}", Name, CalculateAge(), HealthRecord, BestFriendForever.Name);
            }
        }
    
        public class AdultPerson : PersonBase
        {
            public override string HealthRecord { get; set; }
            public AdultPerson(string name, DateTime bd)
                : base(name, bd)
            {
            }
    
            public override string DisplayData()
            {
                return string.Format("Name:{0}  Age:{1}  Health record:{2}", Name, CalculateAge(), HealthRecord);
            }
        }
