    public class MyClass : BaseClass
    {
        public string Name 
        {
            get 
            {
                return this.name; 
            }
            set 
            {
                this.SetName(value);
            }
        }
    }
