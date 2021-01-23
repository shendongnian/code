    class BaseClass
    {
        // This method must become virtual
        public virtual void Init()
        {
            // Do basic stuff.
        }
    }
    class LoginTest : BaseClass
    {
        public override void Init()
        {
            // Other stuff
        }
        public void StraightMethod()
        {
            // Do stuff based on the actions in the inherited Init() method from BaseClass.
            base.Init();
        }
        public void ExceptionMethod()
        {
            // Do stuff where I don't want to do the actions in the inherited method.
            // That is, skip or override the Init() method in the BaseClass class.
            this.Init();
        }
    }
