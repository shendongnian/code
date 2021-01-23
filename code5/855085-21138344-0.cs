        using System;
    using System.Runtime.InteropServices;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Text;
    
    namespace csharp.activex.sample
    {
    	/// <summary>
    	/// A very simple interface to test ActiveX with.
    	/// </summary>
    	[
    		Guid( "E86A9038-368D-4e8f-B389-FDEF38935B2F"),
    		InterfaceType( ComInterfaceType.InterfaceIsDual),
    		ComVisible( true)
    	]
    	public interface IHello
    	{
    		[DispId(1)]
    		string Hello();
    		
    		[DispId(2)]
    		int ShowDialog(string msg);
    	};
    
    	[
    		Guid("873355E1-2D0D-476f-9BEF-C7E645024C32"),
    
    		// This is basically the programmer friendly name
    		// for the guid above. We define this because it will
    		// be used to instantiate this class. I think this can be
    		// whatever you want. Generally it is
    		// [assemblyname].[classname]
    		ProgId("csharpAx.CHello"),
    
    		// No class interface is generated for this class and
    		// no interface is marked as the default.
    		// Users are expected to expose functionality through
    		// interfaces that will be explicitly exposed by the object
    		// This means the object can only expose interfaces we define
    		ClassInterface(ClassInterfaceType.None),
    
    		// Set the default COM interface that will be used for
    		// Automation. Languages like: C#, C++ and VB
    		// allow to query for interface's we're interested in
    		// but Automation only aware languages like javascript do
    		// not allow to query interface(s) and create only the
    		// default one
    		ComDefaultInterface(typeof(IHello)),
    		ComVisible(true)
    	]
    	public class CHello : IHello
    	{
    
    		#region [IHello implementation]
    		public string Hello()
    		{
    			return "Hello from CHello object";
    		}
    
    
    		public int ShowDialog(string msg)
    		{
    			System.Windows.Forms.MessageBox.Show(msg, "");
    			return 0;
    		}
    		#endregion
    	};
    }
