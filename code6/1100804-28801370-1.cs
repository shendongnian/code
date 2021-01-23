    //using System.Runtime.InteropServices;  
    public class ClipboardFunctions  
    {  
    	[DllImport("user32.dll", EntryPoint = "OpenClipboard", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]  
    	public static extern bool OpenClipboard(IntPtr hWnd);  
    
    	[DllImport("user32.dll", EntryPoint = "EmptyClipboard", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]  
    	public static extern bool EmptyClipboard();  
    
    	[DllImport("user32.dll", EntryPoint = "SetClipboardData", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]  
    	public static extern IntPtr SetClipboardData(int uFormat, IntPtr hWnd);  
    
    	[DllImport("user32.dll", EntryPoint = "CloseClipboard", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]  
    	public static extern bool CloseClipboard();  
    
    	[DllImport("user32.dll", EntryPoint = "GetClipboardData", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]  
    	public static extern IntPtr GetClipboardData(int uFormat);  
    
    	[DllImport("user32.dll", EntryPoint = "IsClipboardFormatAvailable", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]  
    	public static extern short IsClipboardFormatAvailable(int uFormat);  
    }  
    
    private void button1_Click(object sender, EventArgs e)  
    {  
    	const int CF_ETAFILE = 14;  
    	IntPtr intptr;  
    
    	System.Drawing.Imaging.Metafile myMetaFile = null;  
    	if (ClipboardFunctions.OpenClipboard(this.Handle))  
    	{  
    		if (ClipboardFunctions.IsClipboardFormatAvailable(CF_ETAFILE) != 0)  
    		{  
    			intptr = ClipboardFunctions.GetClipboardData(CF_ETAFILE);  
    			myMetaFile = new System.Drawing.Imaging.Metafile(intptr, true);  
    			ClipboardFunctions.CloseClipboard();  
    			myMetaFile.Save(@"c:\test.jpg", ImageFormat.Jpeg);  
    		}  
    	}  
    } 
