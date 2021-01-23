    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        public static Singleton Instance { get { return instance; } }
        // Private constructor to prevent instantiation
        private Singleton() {}
        // Instance members from here onwards
    }
