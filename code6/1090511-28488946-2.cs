    public class ComponentControlProxy
    {
        public ComponentControl<int> BindingSource;
        public string A 
        {
            get 
            {
                return BindingSource.A;
            }
            set 
            {
                BindingSource.A = value;
            }
        }
        .. etc
    }
