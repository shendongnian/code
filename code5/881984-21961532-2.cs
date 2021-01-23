    public interface ITest
    {
        void DebugName();
    }
    
    [UnityNamedInstance("TestA")]
    public class TestA : ITest
    {
        #region ITest Members
        public void DebugName()
        {
            Debug.WriteLine("This is TestA");
        }
        #endregion
    }
    [UnityNamedInstance("TestB")]
    public class TestB : ITest
    {
        #region ITest Members
        public void DebugName()
        {
            Debug.WriteLine("This is TestB");
        }
        #endregion
    }
    [UnityNamedInstance("TestC")]
    public class TestC : ITest
    {
        #region ITest Members
        public void DebugName()
        {
            Debug.WriteLine("This is TestC");
        }
        #endregion
    }
