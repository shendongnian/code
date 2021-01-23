    //Early Initalization
    public class Singleton
    {
    private static Singleton instance = new Singleton();
    private Singleton() { }
     
    public static Singleton GetInstance
    {
    get
    {
    return instance;
    }
    }
    }
