    foreach(var y in x.list1Name){
      foreach(PS3BAWSAQ.RootObject z in y){
        PS3BAWSAQ.RootObject obj = new PS3BAWSAQ.RootObject (){
            
           Prop1 = z.Key1,
           Prop2 = z.Key2,
           //And So on
        
        };
      }
    }
