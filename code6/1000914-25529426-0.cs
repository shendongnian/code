            public class Employee 
            {
                public Employee()
                {
                    this.firstName = "Terry";
                    this.lastName = "Wingfield";
                }
    
                public string firstName { get; set; }
                public string lastName { get; set; }
    
                public virtual void writeName()
                {
                    Console.WriteLine(this.firstName + " " + this.lastName);
                    Console.ReadLine();
                }
            }
        public class PartTimeEmployee : Employee 
        {
            public override void writeName() 
            {
                Console.WriteLine("John" + " " + "Doe");
                Console.ReadLine();
            }
        }
        public class FullTimeEmployee : Employee 
        {
            public override void writeName()
            {
                Console.WriteLine("Jane" + " " + "Doe");
                Console.ReadLine();
            }
        }
