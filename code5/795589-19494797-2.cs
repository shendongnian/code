    class MyClass
    {
       public MyClass(int id)
       {
          if (FileExistsOnDisk(id))
          {
             MyClass m = DeserializeFromFile(id);
             CopyFrom(m);
          }
          else
          {
              // Normal construction.
          }
       }
    }
