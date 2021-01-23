    public class UserDetails
    {
       ...
    }
    public partial class FormMain : Form
    {
            private UserDetails mainUD;
    
            public UserDetails MainUD
            {
                get { return mainUD; }
                set { mainUD = value; }
            }
    }
