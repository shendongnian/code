    public partial class Person
    {
        public Person(){
            dob = DateTime.Now; // or whatever
        }
  
        public int id { get; set; }
        public string name { get; set; }
        public System.DateTime dob { get; set; }
    }
