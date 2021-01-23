     class Base 
     {  
         public int Field1 {get;set;}
         virtual void Load(BinaryReader reader)
         {
             Field1 = reader.ReadInt();
         }
     }
     class Derived:Base
     {  
         public int Field2 {get;set;}
         override void Load(BinaryReader reader)
         {
             base.Load(reader);
             Field2 = reader.ReadInt();
         }
     }
  
