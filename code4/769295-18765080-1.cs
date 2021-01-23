    public class YourClass
    {
        /// <summary>
        ///     Singletone instance of 
        /// </summary>
        public static YourClass Instance
        {
            get { return Singletone<YourClass>.Instance; }
        }
    ...methods etc...
    }
