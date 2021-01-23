    public class aaaaa
    {
        public WeakReference<smallclass> h;
        public void fun1(smallclass d)
        {
            h = new WeakReference<smallclass>(d);
        }
        public void fun2()
        {
            smallclass k;
            if(h.TryGetTarget(out k))
            Console.WriteLine(k.j);
            else
                Console.WriteLine("ERROR ERRROR ERROR");
        }
    }
