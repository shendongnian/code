    public class Course
    {
        public string GetFormalDate()
        {
            // recursive call, with no terminating condition,
            // will infinitely call itself until there is no
            // more stack to store context data (and CLR
            // will then throw an exception)
            return GetFormalDate(); 
        }
    }
    
