    public interface Quark
    {
        void Do();
    }
    
    public interface SpecificQuark : Quark
    {
        void DoSpecificThing();
    }
    
    public class Strange : SpecificQuark
    {
        public virtual void Do()
        {
            // Something is done
        }
    
        public void DoSpecificThing()
        {
            Console.WriteLine("Specific Thing!");
        }
    }
    
    public class Charm : SpecificQuark
    {
        public virtual void Do()
        {
            // Something else is done
        }
    
        public void DoSpecificThing()
        {
            Console.WriteLine("Another Specific Thing!");
        }
    }
    
    class ReUsableCode<T>
        where T: SpecificQuark, new()
    {
        public T InnerQuark { get; private set; }
        
        public ReUsableCode()
        {
            this.InnerQuark = new T();
        }
        
        public void Do()
        {
            // Let's pretend this is around 2000 lines of
            // 90's-style Win32 message spaghetti.
            
            Console.WriteLine(InnerQuark.GetType().ToString() + " did!");
            this.InnerQuark.Do();
        }
    }
    
    class LibraryStrange : ReUsableCode<Strange>
    {
    }
    
    class LibraryCharm : ReUsableCode<Charm>
    {
    }
    
