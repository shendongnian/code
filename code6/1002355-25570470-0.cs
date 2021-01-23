    class BaseClass {
        public virtual void Init () {
            // Do basic stuff.
        }
    
    }
    
    class LoginTest : Baseclass {
        public override void Init() {
            //do overridden stuff
        }
        public void StraightMehthod () {
            this.Init(); // Call the overridden
        }
    
        public void ExceptionMethod () {
            base.Init(); // Call the base specifically
        }
    }
