    public class ScreenBoundsWrapper
    {
        public ScreenBoundsWrapper()
        {            
        }
        public ScreenBoundsWrapper(Screen screen)
        {
            screenInstance = screen;
        }
        public Screen ScreenInstance
        {
            get { return screenInstance; }
        }
        public virtual Rectangle Bounds
        {
            get { return ScreenInstance.Bounds; }
        }
        public override bool Equals(object obj)
        {
            var w = obj as ScreenBoundsWrapper;
            if (w != null)
            {
                return w.ScreenInstance.Equals(screenInstance);
            }
            return obj.Equals(this);
        }
        protected bool Equals(ScreenBoundsWrapper other)
        {
            return Equals(screenInstance, other.screenInstance);
        }
        public override int GetHashCode()
        {
            return screenInstance == null ? 0 : screenInstance.GetHashCode();
        }
        private readonly Screen screenInstance;
    }
