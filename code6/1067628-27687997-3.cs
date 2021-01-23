       public class ObjectEvaluator 
       {
            private static string getObjectType (Int obj) {
                return String.Format("The type of input object is {0}", obj.GetType());
            }
        
            private static string getObjectType (string obj) {
                return String.Format("The type of input object is {0}", obj.GetType());
            }
       }
