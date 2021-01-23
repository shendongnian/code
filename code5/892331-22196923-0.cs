    class Test
    {
        static object o = new object();
    }
    
    class Test
    {
        static object o;
    
        static Test()
        {
            o = new object();
        }
    } 
