    public unsafe class Wrapper
    {
        public Rep* q;
        public Wrapper()
        {
            q = (Rep*)Marshal.AllocHGlobal(sizeof(Rep));
            q->refcount = 1;
            q->size = 0;
            q->data = null;
        }
        ~Wrapper()
        {
            Marshal.FreeHGlobal((IntPtr)q);
        }
        public Rep* rep()
        {
            return q;
        }
    }
