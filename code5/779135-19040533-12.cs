    [ComVisible(true), Guid("2FE5D78D-D9F2-4236-9626-226356BA25E7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISetCallback
    {
        void OnSetText(string value);
    }
    
    public class A : ISetCallback
    {
        public void OnSetText(string value) // ISetCallback
        {
            MessageBox.Show(value);
        }
    
        public void Test(Icom icom)
        {
            icom.Set(this);
        }
    }
    
    [ComVisible(true), Guid("81C99F84-AA95-41A5-868E-62FAC8FAC263"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface Icom
    {
        void Set(ISetCallback callback);
    }
    
    [ComVisible(true)]
    [Guid("6DF6B926-8EB1-4333-827F-DD814B868097")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(Icom))]
    public class B : Icom
    {
        public void Set(ISetCallback callback)
        {
            callback.OnSetText("some text");
        }
    }
    
    private void buttonTest_Click(object sender, EventArgs e)
    {
        var a = new A();
        var b = new B();
    
        a.Test(b);
    }
 
