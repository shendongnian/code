    public static class Managers
    {
        private static SomeManager someManagerInstance;
        public static SomeManager Manager
        {
             get
             {
                 if (someManagerInstance == null)
                 {
                     someManagerInstance = new SomeManager();
                 }
                 return someManagerInstance;
             }
        }
    }
