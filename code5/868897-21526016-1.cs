	using System;
	using System.Drawing;
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
		    string[] names = fonts.GetValueNames();
		    StringBuilder nameb = new StringBuilder(font.Name);
		    if(font.Bold)
		    	nameb.Append(" Bold");
		    if(font.Italic)
		    	nameb.Append(" Italic");
		    nameb.Append(" (TrueType)");
		    string fullname = nameb.ToString();
		    string basename = font.Name+" (TrueType)";
		    object file = fonts.GetValue(fullname);
		    if(file == null && fullname != basename)
		    {
		    	file = fonts.GetValue(basename);
		    }
		    if(file != null) return file.ToString();
		    return null;
		}finally{
			if(fonts != null)
			{
				fonts.Dispose();
			}
		}
	}
