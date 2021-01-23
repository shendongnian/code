    class Agent : Person 
    {
        public static Agent operator ++(Agent p)
        {
            p.Age++;
            return p;
        }
    }
