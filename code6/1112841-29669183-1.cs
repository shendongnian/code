    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace Assets.Scripts
    {
    	public class DLLCall
    	{
    
    		[DllImport("thedll")]
    		public static extern void TheCall(IntPtr byteArray, int size);
    
    		public void PerformCall(byte[] data)
    		{
    			IntPtr unmanagedArray = Marshal.AllocHGlobal(data.Length);
    			Marshal.Copy(data, 0, unmanagedArray, data.Length);
    
    			TheCall(unmanagedArray, data.Length);
    
    			Marshal.FreeHGlobal(unmanagedArray);
    		}
    
    	}
    }
