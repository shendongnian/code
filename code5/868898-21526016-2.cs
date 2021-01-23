	using System;
	using System.Drawing;
	using System.Text.RegularExpressions;
	using Microsoft.Win32
 
	public static string GetSystemFontFileName(Font font)
	{
	    RegistryKey fonts = null;
	    try{
	        fonts = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Fonts", false);
	        if(fonts == null)
	        {
	            fonts = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Fonts", false);
	            if(fonts == null)
	            {
	                throw new Exception("Can't find font registry database.");
	            }
	        }
	        
	        string suffix = "";
	        if(font.Bold)
	            suffix += "(?: Bold)?";
	        if(font.Italic)
	            suffix += "(?: Italic)?";
	        
	        var regex = new Regex(@"^(?:.+ & )?"+Regex.Escape(font.Name)+@"(?: & .+)?(?<suffix>"+suffix+@") \(TrueType\)$", RegexOptions.Compiled);
	        
	        string[] names = fonts.GetValueNames();
	        
	        string name = names.Select(n => regex.Match(n)).Where(m => m.Success).OrderByDescending(m => m.Groups["suffix"].Length).Select(m => m.Value).FirstOrDefault();
	        
	        if(name != null)
	        {
	        	return fonts.GetValue(name).ToString();
	        }else{
	        	return null;
	        }
	    }finally{
	        if(fonts != null)
	        {
	            fonts.Dispose();
	        }
	    }
	}
