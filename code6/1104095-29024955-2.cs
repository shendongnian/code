    public class SomethingRelation{
        public ISomething something;
        public ISomething2 something2;
    }
    public class ManagerClass{
        public IEnumerable<ISomething> ISomethings { get; set; }
        public IEnumerable<ISomething2> ISomethings2 { get; set; }
        public IEnumerable<SomethingRelation> Relations { get; set; }
        
        public void RemoveSomething2(ISomething2 something2){
            //iterate through SomethingRelation and remove all the something2 reference
        }
    }
