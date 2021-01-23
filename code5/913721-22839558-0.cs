     public enum Gender
        {
            Men,Women
        }
        public class Human
        { 
        }
        class Men : Human
        {
        }
        class Women : Human
        {
        }
    
        class Meeting
        {
            List<Human> visitors = new List<Human>();
    
            public Meeting(Gender m, int Number)
            {
                string ClassName ="YourNameSpace."+ m.ToString();
                Type type = Type.GetType(ClassName);
                object instance = Activator.CreateInstance(type);
                for(int i=0; i<Number; i++)
                {
                visitors.Add(instance as Human);
                }
    
            }
    
        }
