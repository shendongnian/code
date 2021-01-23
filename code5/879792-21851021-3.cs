    public class Test
    {
        public static void TestMethod(string someMessage)
        {
            MessageBox.Show(someMessage);
        }
        [ExecuteDelegateOnPropertySetAspect(typeof(Test), "TestMethod", new object[] { "Hello world!" })]
        public string TestProperty { get; set; }
    }
