        unsafe
        {
         IntPtr pointer =  Args.InBuffer.Read(); 
         // create a pointer to a double
         double* pd = (double*)pointer.ToPointer();
         // Now you can access *pd
         double firstDouble = *pd;
         pd++;  // moves to the next double in the memory block
         double secondDouble = *pd;
         // etc.
         }
