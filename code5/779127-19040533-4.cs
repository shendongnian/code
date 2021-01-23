    public class A
    {
    	public delegate void SetTextDel(string value);
    
    	void TestSetText(string value)
    	{
    		MessageBox.Show(value);
    	}
    
    	public void Test(Icom icom)
    	{
    		SetTextDel del = TestSetText;
    		icom.Set(del);
    	}
    }
    
    [ComVisible(true), Guid("81C99F84-AA95-41A5-868E-62FAC8FAC263"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface Icom
    {
    	void Set(Delegate del);
    }
    
    [ComVisible(true)]
    [Guid("6DF6B926-8EB1-4333-827F-DD814B868097")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(Icom))]
    public class B : Icom
    {
    	public void Set(Delegate del)
    	{
    		del.DynamicInvoke("some text");
    	}
    }
    
    private void buttonTest_Click(object sender, EventArgs e)
    {
    	var a = new A();
    	var b = new B();
    
    	a.Test(b);
    }
