    public class MyObjectSearch : MyObject {
    
        // Other code
        
        public static MyObjectSearch CloneFromMyObject(MyObject obj)
        {
            var newObj = new MyObjectSearch();
            
            // Copy properties here
            obj.Prop1 = newObj.Prop1;
            
            return newObj;
        }
    }
