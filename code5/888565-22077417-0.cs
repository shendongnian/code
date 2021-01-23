    void Main()
    {
        Test t = new Test();
    
        t.MyEvent += new EventHandler (t.DoNothing);
        t.MyEvent -= null;
    }
    
    class Test
    {
        public event EventHandler MyEvent
        {
            add
            {
                Console.WriteLine ("add operation");
            }
    
            remove
            {
                Console.WriteLine ("remove operation");
            }
        }
    
        public void DoNothing (object sender, EventArgs e)
        {
        }
    }
