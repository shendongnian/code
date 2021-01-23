    public interface IStatus
    {
        void TestStatus();
    }
    public interface Control
    {
        void testControl();
    }
    public interface IMainClass {}
    internal class MainClass : IMainClass
    {
        public IStatus status1;
        public IControl control1;
    }
    internal class Status : IStatus
    {
        public IMainClass mainClass;
        public void testStatus()
        {
            mainClass.control1.testControl();
        }
    }
    internal class Control : IControl
    {
        public void testControl()
        {
        }
    }
