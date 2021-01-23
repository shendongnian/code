        public class SomeModel
        {
        //... 
         public override bool Equals(object obj)
            {
          var type = this.GetType();
          bool SameObj = true;
         //for each public property from 'SomeModel'
         //[EDITED]Sorry i'm using custom extension methode here
         //[EDITED]type.GetProperties().Each(prop=>{
         //you should probably use this instead
         type.GetProperties().ToList().ForEach(prop=>{
                          //dynamically checks there equals
                          if(!prop.GetValue(this,null).Equals(prop.GetValue(obj,null))){
                              SameObj=false;
                          }
                        }
                    return SameObj;
        }
       }
