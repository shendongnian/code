    public class MyClassFactory
    {
       public MyClass GetObj(int id)
       {
          if (FileExistsOnDisk(id))
             return DeserializeFromFile(id);
          else 
             return new MyClass(id);     
       }
    }
