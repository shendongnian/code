    public interface ITest
    {
        void DebugName();
    }
    
    [UnityNamedInstance("Test A")]
    public class TestA : ITest
    {
        #region ITest Members
        public void DebugName()
        {
            Debug.WriteLine("This is TestA");
        }
        #endregion
    }
    [UnityNamedInstance("Test B")]
    public class TestB : ITest
    {
        #region ITest Members
        public void DebugName()
        {
            Debug.WriteLine("This is TestB");
        }
        #endregion
    }
    [UnityNamedInstance("Test C")]
    public class TestC : ITest
    {
        #region ITest Members
        public void DebugName()
        {
            Debug.WriteLine("This is TestC");
        }
        #endregion
    }
