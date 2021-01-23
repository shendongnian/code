    interface I
    {
    }
    class A :I
    {
    }
    Class B:I
    {
    }
    class intermediate
    {
        public I GetInstance(int i)
        {
            if(i==1)
               return new A();
            else
                return new B(); 
        }
      
    }
    class clientclass
    {
          I client=new intermediate().GetInstance(1);
    }
