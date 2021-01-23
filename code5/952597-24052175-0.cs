    public class Singleton : MonoBehaviour
    {
       private static Singleton _instance;
       // Will be called before anything, don't even worry about it, instance be initialized.
       void Awake()
       {
          _instance = this;
       }
       public static Singleton getInstance()
       {
          return _instance;
       }
    }
