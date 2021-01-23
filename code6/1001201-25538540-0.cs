    public class Role
    {
        private bool _isUndefined;
        private int _val;
        private Role()
        {
            _isUndefined = true;
        }
 
        private Role(int val)
        {
            _val = val;
        }
       
        public static Role Undefined
        {
            get { return new Role(); }
        }
        public static implicit operator Role(int val)
        {
            return new Role(val);
        }
    }
