        public class SomeModel
        {
        //... 
         public override bool Equals(object obj)
            {
          var type = this.GetType();
          bool SameObj = true;
         //for each public property from 'SomeModel'
         //[EDITED]type.GetProperties().Each(prop=>{ //  Sorry i'm using custom extension methode here
         //you should probably use this instead
         type.GetProperties().ToList().ForEach(prop=>{
                          //dynamically checks that they're equals 
                          if(!prop.GetValue(this,null).Equals(prop.GetValue(obj,null))){
                              SameObj=false;
                          }
                        }
                    return SameObj;
        }
       }
