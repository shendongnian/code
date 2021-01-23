    class BaseClass
    {
        public void Init()
        {
            // Do basic stuff.
            Console.WriteLine("BaseClass.Init");
        }
    }
    class LoginTest : BaseClass
    {
        public void StraightMehthod()
        {
            // Do stuff based on the actions in the inherited Init() method from BaseClass.
            base.Init();
        }
        public void ExceptionMethod()
        {
            // Do stuff where I don't want to do the actions in the inherited method.
            this.Init();
            // That is, skip or override the Init() method in the BaseClass class.
        }
        private new void Init()
        {
            Console.WriteLine("LoginTest.Init");
        }
    }
