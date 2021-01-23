    class derp<T,V> where T:BaseService 
                    where V:MyOtherClass
    {
        public T top;
        public V vop;
    
        public derp(T to, V vo)
        {
            top = to;
            vop = vo;
            top.ToString();
        }
    }
