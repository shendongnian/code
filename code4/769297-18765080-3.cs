    public class YourClass
    {
        /// <summary>
        ///     Singleton instance of 
        /// </summary>
        public static YourClass Instance
        {
            get { return Singleton<YourClass>.Instance; }
        }
    ...methods etc...
    }
