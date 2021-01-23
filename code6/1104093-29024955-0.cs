    public class ManagerClass{
        public IEnumerable<ISomething> ISomethings { get; set; }
        public IEnumerable<ISomething2> ISomethings2 { get; set; }
        public void RemoveSomething2(ISomething2 something2){
            //iterate through ISomething and remove the ClassB reference
        }
    }
