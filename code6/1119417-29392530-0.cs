        public class SomeModel
        {
        //... 
         public override bool Equals(object obj)
            {
          var type = this.GetType();
          bool SameObj = true;
         //for each public property from 'SomeModel'
         type.GetProperties().Each(prop=>{
                          //dynamically checks there equals
                          if(!prop.GetValue(this,null).Equals(prop.GetValue(obj,null)){
                              SameObj=false;
                          }
                        }
                    return SameObj;
        }
       }
