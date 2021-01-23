    class C:B
    {
       public Start()
       {          
          ((B)this).Start(); // same as base.Start();
        }
    }
