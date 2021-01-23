    public class Person
    {
        public string A;
        public string B;
        public string C;
        ...
        public string Z;
    
        private void Ininialize() {
          this.A = "Default value for A";
          this.B = "Default value for B";
          this.C = "Default value for C";
          ...
          this.Z = "Default value for Z";
        }
    
        public Person()
        {
           Ininialize();
        }
    
        public void Clear()
        {
           Ininialize();
        }
    }
....
    Person p = new Person();
    ...
    p.A = "Something goes here for A";
    p.B = "Something goes here for B";
    ...
    p.Clear(); // <- return A, B..Z properties to their default values
