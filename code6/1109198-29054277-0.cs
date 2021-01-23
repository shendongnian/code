    public class TestForm : Form
    {
        private TestForm()
        {
        }
        public static async Task<TestForm> Create()
        {
            await myMethod();
            return new TestForm();
        }
    }
