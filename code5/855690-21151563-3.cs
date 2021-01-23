    public class CustomControlA : UserControl
    {
        public void OverrideableMethod() 
        {
           //You can code here for things before the overrideable method
           OnOverrideableMethod();
           //You can code here for things after the overrideable method
        }
        protected virtual void OnOverrideableMethod() { }
    }
    public class UserControlB : CustomControlA
    {
        protected override void OnOverrideableMethod() 
        {
           /*  implement here */
        }
    }
