    public class MyFragment
    {
        /// members + methods
        public void proc() 
        {
            // just pass dummy argument
            ProcEx(new MyProc());
        }
    
        public void ProcEx(MyProc myProc)
        {
           // fill myProc
        }
    }
    
    public class MyClass
    {
       private MyProc m_proc;
       private MyFragment m_frag;
       public MyClass(MyFragment fr)
       {
           m_proc = new MyProc();
           m_frag = new MyFrag();
           m_frag.ProcEx(m_proc);
       }
    }
