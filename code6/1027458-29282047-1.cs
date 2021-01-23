    using System;
    using System.Runtime.InteropServices;
    
    using Foundation;
    using UIKit;
    using ObjCRuntime;
    
    public static class UIViewAutolayoutTraceExtensions
    {
    	[DllImport(Constants.ObjectiveCLibrary, EntryPoint="objc_msgSend")]
    	private static extern IntPtr IntPtr_objc_msgSend (IntPtr receiver, IntPtr selector);
    
    	public static NSString AutoLayoutTrace(){
    		return (NSString)Runtime.GetNSObject(IntPtr_objc_msgSend(UIApplication.SharedApplication.KeyWindow.Handle, new Selector ("_autolayoutTrace").Handle));
    	}
    
    	public static NSString RecursiveDescription(){
    		return (NSString)Runtime.GetNSObject(IntPtr_objc_msgSend(UIApplication.SharedApplication.KeyWindow.Handle, new Selector ("recursiveDescription").Handle));
    	}
    }
