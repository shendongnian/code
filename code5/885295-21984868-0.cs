    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.ExtraProperties.HairColor = "Green";
            p1.ExtraProperties.DateOfGraduation = DateTime.UtcNow;    
            
            foreach (var prop in p1.ExtraProperties)
            {
                Console.WriteLine(prop.Key + ": " + prop.Value);
            }
    
        }
    }
    
    public class Person
    {
        private System.Dynamic.ExpandoObject _extraProperties = new System.Dynamic.ExpandoObject();
    
        public string Name { get; set; }
        public DateTime BornDate { get; set; }
    
        public dynamic ExtraProperties
        {
            get { return _extraProperties; }
        }
    
    }
