    // In the Contracts assembly
    // Defines the same functionality as was in your static class.
    public interface IServiceContract
    {
        void SomeServiceMethod();
    }
    // For the classes dynamically loaded from the DLL
    public interface IAddIn
    {
        void TestMethod();
    }
---
    // In the dynamically loaded assembly
    public class AddInClass : IAddIn
    {
        private IServiceContract _service;
        public AddInClass(IServiceContract service)
        {
            _service = service;
        }
        public void TestMethod()
        {
            _service.SomeServiceMethod();
        }
    }
