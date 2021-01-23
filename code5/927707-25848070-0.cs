    namespace Data_driven_testing
    {
    /// <summary>
    /// Summary description for CodedUITest2
    /// </summary>
    [CodedUITest]
    
    public class CodedUITest2
    {
        public CodedUITest2()
        {
        }
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xls)};dbq=D:\\CodedUI\\Data_driven_testing\\Data_driven_testing\\Data.xls;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "Sheet2$", DataAccessMethod.Sequential), TestMethod]
        
        public void CodedUITestMethod1()
        {
            this.UIMap.RecordedMethod3Params.UITextBox1EditText = TestContext.DataRow["Input1"].ToString();
            this.UIMap.RecordedMethod3Params.UITextBox2EditText = TestContext.DataRow["Input2"].ToString();
            this.UIMap.RecordedMethod3();
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        }
     namespace Data_driven_testing
     {
       /// <summary>
       /// Summary description for CodedUITest1
       /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }
        //[TestMethod]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xls)};dbq=D:\\CodedUI\\Data_driven_testing\\Data_driven_testing\\Data.xls;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "Sheet1$", DataAccessMethod.Sequential), TestMethod]
        public void CodedUITestMethod1()
        {
            this.UIMap.RecordedMethod1Params.UITextBox3Text = TestContext.DataRow["Input1"].ToString();
            this.UIMap.RecordedMethod1Params.UITextBox4EditText = TestContext.DataRow["Input1"].ToString();
            this.UIMap.RecordedMethod1();
            this.UIMap.RecordedMethod2Params.UITextBox5EditText = TestContext.DataRow["Input3"].ToString();
            this.UIMap.RecordedMethod2Params.UITextBox6EditText = TestContext.DataRow["Input4"].ToString();
            // this.UIMap.RecordedMethod2();
        }
