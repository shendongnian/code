      [HandleProcessCorruptedStateExceptions]
       public Message(int value)
       {
    
        try
          {
             _testStruct=(TestStruct*)Memory.Alloc(sizeof(TestStruct));
     
             Test(_testStruct, value);
          }
        Catch(AccessViolationException ex)
          {
             //Read the exception here
          }
       }
