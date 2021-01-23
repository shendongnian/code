    public class MyDerived : MyBase
    {
        #region Singleton Pattern
        public static readonly MyDerived Instance = new MyDerived();
        private MyDerived()
        {
        }
        #endregion
    }
