       public class Person
    {
        public string A;
        public string B;
        public string C;
        ...
        public string Z;
    
        public Person()
        {
            resetToDefault();
        }
    
        public void Clear()
        {
            resetToDefault();
        }
        public void resetToDefault()
        {
            this.A = "Default value for A";
            this.B = "Default value for B";
            this.C = "Default value for C";
            ...
            this.Z = "Default value for Z";
        }
    }
