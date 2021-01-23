    //invoke.cs
    //compile with: csc /nologo invoke.cs
    using System;
    using System.Runtime.InteropServices;
    class Program
    {
    	[DllImport( "invoke.dll" )]
    	private static extern IntPtr getPointer();
	
    	private delegate void TestCallbackDelegate(); //Delegate that matches the signature of test_callback
	
    	static void main()
    	{
    		IntPtr ptr = getPointer(); //Fetch the native void pointer.
    		TestCallbackDelegate test_callback = Marshal.GetDelegateForFunctionPointer<TestCallbackDelegate>( ptr ); //Marshal the void pointer to a delegate.
    		test_callback(); //Invoke the native C function.
    	}
    }
