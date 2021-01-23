    interface ICanTalk
    {
        string Talk();
    }
    class Singleton : ICanTalk
    {
        private Singleton() { }
        private readonly Singleton _instance = new Singleton();
        public Singleton Instance
        { get { return _instance; } }
        public string Talk()
        { return "this is a singleton"; }
    }
