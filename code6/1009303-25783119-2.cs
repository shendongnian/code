        public class MyObject2{
        ...
        }
    
        public class MyObject3{
        ...
        }
        ...
    
    Object obj = null;
    try{
     obj = JsonConvert.DeserializeObject<MyObject>(data); 
    }catch{
          try{
          obj = JsonConvert.DeserializeObject<MyObject2>(data);
          }catch{
               try{
                 obj = JsonConvert.DeserializeObject<MyObject3>(data);
               }catch{
                 //Log error new type of data received
                 throw new Exception();
               }
          }
     
    }
    if (obj.GetType() == typeof(MyObject)){
       ...
    }else if (obj.GetType() == typeof(MyObject2)){
       ...
    }
    ....
