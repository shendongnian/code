    public class Test
    {
        public async Task<TestResult> TestAsync()
        {
            await Task.Delay(1000); // Imagine an I/O operation.
            return new TestResult();
        }
    }
