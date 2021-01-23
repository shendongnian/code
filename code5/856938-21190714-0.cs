    public class SomeClass{
        StringAnalyzer stringAnalizer = new StringAnalizer();
        Logger logger = new Logger();
       
        public void SomeMethod(){
            if (stringAnalyzer.IsValid(someParameter))
            {
                //do something with someParameter
            }else
            {
                logger.Log("Invalid string");
            }       
        }
    }
