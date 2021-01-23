        public class SomeType
    {
        public event EventHandler Input;
        public void Raise()
        {
            if (Input != null)
            {
                Input(this, new EventArgs());
            }
        }
    }
    public class SomeOtherType
    {      
        public void Output(object source, EventArgs handler)
        {
            Console.WriteLine("Handled");
        }
    }
