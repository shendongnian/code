    public class Logger
    {
       private static Dictionary<int, List<Action<string>>> _callbacks = new Dictionary<int,List<Action<string>>>();
        public static void RegisterLoggerCallback(int errorType, Action<string> callback)
        {
            // Just using errortype in this exaple, but the key can be anything you want.
            if (!_callbacks.ContainsKey(errorType))
            {
                _callbacks.Add(errorType, new List<Action<string>>());
            }
            _callbacks[errorType].Add(callback);
        }
        public static void RegisterLog(int errorType, int errorID)
        {
            // find error sring with codes
            string error = "MyError";
          
            // show messagebox
            MessageBox.Show(error);
            // tell listeners
            if (_callbacks.ContainsKey(errorType))
            {
                _callbacks[errorType].ForEach(a => a(error));
            }
        }
    }
    public class Model
    {
        public Model()
        {
        }
        public void DoSomething()
        {
          Logger.RegisterLog(1, 2);
        }
    }
    public class Presenter 
    {
        public Presenter()
        {
            Logger.RegisterLoggerCallback(1, AddToListbox);
        }
        private void AddToListbox(string error)
        {
            // add to listbox when errortype 1 is called somewhere
        }
    }
