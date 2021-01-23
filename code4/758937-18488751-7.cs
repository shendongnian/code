    interface ICanTalk
    {
        string Talk();
    }
    class Singleton : ICanTalk
    {
        private Singleton() { }
        private static readonly Singleton _instance = new Singleton();
        public static Singleton Instance
        { get { return _instance; } }
        public string Talk()
        { return "this is a singleton"; }
    }
