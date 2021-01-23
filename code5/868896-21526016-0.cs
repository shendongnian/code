	using System;
	using System.Drawing;
	using Microsoft.Win32
 
	public static string GetSystemFontFileName(Font font)
	{
		string fontname = font.Name+" (TrueType)";
		RegistryKey fonts = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Fonts", false);
		if(fonts == null)
		{
			fonts = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Fonts", false);
			if(fonts == null)
			{
				throw new Exception("Can't find font registry database.");
			}
		}
		foreach(string fntkey in fonts.GetValueNames())
		{
			if(fntkey == fontname)
			{
				return fonts.GetValue(fntkey).ToString();
			}
		}
		return null;
	}
