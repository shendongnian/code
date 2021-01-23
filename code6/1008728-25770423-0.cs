    public class Test
    {   
        public delegate void MyDelegate(int arg1, int arg2);
    
        public event MyDelegate SomethingHappened;
        
        public void RaiseEvent(int a, int b)
        {
            var temp = SomethingHappened;
            if(temp != null)
            {
                temp(a, b);
            }
        }    
    }
