    [ComSourceInterfaces(typeof(_DllAppEvents))]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("C7FA28F7-7A8D-45BA-9F0B-2C6CD8FB8650")]
    [ProgId("TestDll.Test")]
    public partial class DllApp : Window
    {
        // my event
        public event MyEventHandler MyEvent;
        // button event
        void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // call the event
            MyEvent();
        }
    }
