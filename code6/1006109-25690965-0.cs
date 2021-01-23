    interface ILoad {
        string GetName();
    }
    class A : ILoad {
        public string PropA { get; set; }
        public string GetName()
        {
            return "Class A";
        }
    }
    class B : ILoad {
        public string PropB { get; set; }
        public string GetName()
        {
            return "Class B";
        }
    }
