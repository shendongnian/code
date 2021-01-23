    public class SomeObject : IEnumerable<SomeObject>
    {  
        private List<SomeObject> myList = new List<SomeObject>();
        public IEnumerable<SomeObject>(){
            return myList.GetEnumerator();
        }
    }
