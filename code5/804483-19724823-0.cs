    class Person<T> where T : Person<T>{
        public int Age;
    
        public static T operator ++(T p)
        {
            p.Age++;
            return p;
        }
        
    }
    
    class Agent : Person<Agent> {   }
