    public class Gender
    {
        public readonly string Name { get; set;}
        public readonly char Abbreviation { get; set;} 
        public readonly string ChildName { get; set;}
        public readonly int Number { get; set;}
    
        private Gender()
        {
        }
    
        public static Gender Male = new Gender { Name = "Male", Abbreviation = 'M', Number = 1, ChildName = "Boy" };
        public static Gender Female = new Gender { Name = "Female", Abbreviation = 'F', Number = 2, ChildName = "Girl" };
        public static Gender Unknown = new Gender { Name = "Unknown", Abbreviation = 'U', Number = 0, ChildName = "Unknown" };
    }
