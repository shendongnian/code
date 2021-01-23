    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication
    {
        [ComVisible(true)]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IApp
        {
            void testFunction();
        }
    
        [ComVisible(true)]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface ITestObject
        {
            IApp App { get; }
        }
    
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None)]
        [ComDefaultInterface(typeof(ITestObject))]
        public class TestObject: ITestObject
        {
            readonly App _app = new App();
    
            public IApp App
            {
                get { return _app; }
            }
        }
    
        [ComVisible(true)]
        public class App : IApp
        {
            public void testFunction()
            {
                MessageBox.Show("Hello!");
            }
        }
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.webBrowser1.ObjectForScripting = new TestObject();
                this.webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
                this.webBrowser1.Navigate("about:blank");
            }
    
            void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                this.webBrowser1.Navigate("javascript:external.App.testFunction()");
            }
        }
    }
