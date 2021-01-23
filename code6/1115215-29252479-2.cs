    public class Foo
    {
        public event Action theEvent;
        public void OpenPage1()
        {
            if (theEvent != null)
                theEvent();
        }
        public void OpenPage2()
        {
            if (theEvent != null)
                theEvent();
        }
    }
    public class Bar
    {
        public int Counter { get; set; }
        public void PerformSomeTask()
        {
            Counter++;
        }        
    }
