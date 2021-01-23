       public class MyContainer:Control
       {
        public MyContainer(string szControlName, UserControl nControl)
        {
            UserControlName = szControlName; MyControl = nControl;
        }
           public string UserControlName { get; set; }
           public UserControl MyControl { get; set; }
       }
