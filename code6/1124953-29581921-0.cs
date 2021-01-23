    public abstract class Singleton<T> where T : Window, Singleton<T>
    {
        protected static Func<T> create;
        private static T instance;
        public static T Instance { get { return instance ?? (instance = create()); } }
        private sealed override void OnClosed(EventArgs e)
        { 
            instance = null;
        }
    }
    public class MyWindow : Singleton<MyWindow>
    {
        static MyWindow()
        {
            create = () => new MyWindow();
        }
        private MyWindow() { }
    }
