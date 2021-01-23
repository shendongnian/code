    interface A
    {
        int MustReturn3();
    }
   
    class B : A
    {
       public int MustReturn3()
       {
          return Get3();
       }
       public int Get3()
       {
          return 2 + 1;
       }
    }
