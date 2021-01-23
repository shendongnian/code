    public class class1
    {
        private static MyObject p_var;
        public static MyObject MyVar
        {
            get
            {
                if (p_var == null)
                {
                    p_var = new MyObject();
                    p_var.attr1 = "test init";
                }
                return p_var;
            }
        }
    }
