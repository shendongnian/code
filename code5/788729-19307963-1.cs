        public class MyType
        {
            public String Name, Type, Switch;
            public MyType()
            {
            }
            public MyType(string _name, string _type, string _switch)
            {
                Name = _name;
                Type = _type;
                Switch = _switch;
            }
            public override string ToString()
            {
                return "Name = " + this.Name + ",Type = " + this.Type + ",Switch = " + this.Switch;
            }
        }
