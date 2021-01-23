    //PublicLibrary.dll 
    public class PublicExampleClass
    {
       public string SomeMethod()
       {
           //simplify CurrentLibrary
           return new CurrentLibrary.Serializer()
               .SerializeCurrentLibrayrObject(new CurrentLibraryObject());
       }
    }
    //CurrentLibrary.dll
    public class Serializer
    {
        public string SerializeCurrentLibrayrObject(CurrentLibraryObject obj){
           //Serialize obj
        }
    }
     
