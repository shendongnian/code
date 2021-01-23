    public class MetroWindowManager : WindowManager, Communicator.Core.IWindowManager
    {
        private IDictionary<WeakReference, WeakReference> windows = new Dictionary<WeakReference, WeakReference>();
        public void Blink(object rootModel)
        {
            //have access to 'windows' dictionary
        }
