    unsafe struct Test
    {
      public fixed byte Data[1024];
    }
    
    unsafe void Main()
    {
        Test[] test = new Test[16 * 1024 * 1024];
        
        // We've got 16 * 1024 * 1024 * 1024 here.
        fixed (Test* pTest = test)
        {
         
        }
    }
