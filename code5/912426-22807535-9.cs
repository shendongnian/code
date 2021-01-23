     [DataContract]
         public class BaseCustomEncMessage
        {
            private Object _object = null;  
            [DataMemberAttribute]
            public Object CipheredMessage { get { return _object; } }
            public void Cipher(object obj )
            {
                 //here you can use 3DES for example and serialize your instance as an object 
    
            }
        }
