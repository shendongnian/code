    class C1 : IWhatsMyAgeAgain, ISayMyName
    {
        public int    Age;
        public string Name;
        
        public string GetName() { return Name; }
        public int    GetAge() { return Age; }
    }
