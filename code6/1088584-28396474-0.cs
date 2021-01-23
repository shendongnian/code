    public class BaseClass
    {
        protected BaseClass()
        {
            Entities = new Entities();
        }
        protected Entities Entities { get; private set; }
    }
