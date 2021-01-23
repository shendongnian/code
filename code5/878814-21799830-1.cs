    public class Observer
    {
        public delegate void SomethingHappenedDelegate();
        public void NoReallySomethingHappened()
        {
            if(SomethingHappened != null)
                SomethingHappened();
        }
        public event SomethingHappenedDelegate SomethingHappened;
    }
