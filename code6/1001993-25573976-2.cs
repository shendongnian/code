    public static class WordColorTest {
    	public static void GetColors() {
    
    		Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
    		Documents docs = app.Documents;
    		Document doc = docs.Open("C:\\temp\\ColorTest3.docx", ReadOnly:true);
    		StringBuilder sb = new StringBuilder();
    		sb.AppendLine("<html><body>");
    		sb.AppendLine("<table border=1 style='font-family:Arial;'>");
    		sb.AppendLine("<tr><th>Text</th><th>RGB</th><th>Color</th></tr>");
    		Dictionary<Color,int> counts = new Dictionary<Color,int>();
    
    		foreach (Range rng in doc.StoryRanges) {
    			foreach (Range rngChar in rng.Characters) { // by each character
    				_Font f = rngChar.Font;
    				int rgb = (int) f.Color;
    				//System.Drawing.Color col = System.Drawing.ColorTranslator.FromOle(rgb); // do not use - not 1-to-1
    				var col = RgbColorRetriever.GetRGBColor(f.Color, doc);
    				//ColorFormat cf = f.TextColor; // error - exception on ".doc" files
    				sb.AppendLine(String.Format("<tr><td>{0}</td><td>{1},{2},{3}</td><td bgcolor='{4}'></td></tr>", rngChar.Text, col.R, col.G, col.B, ToHex(col)));
    				//sb.AppendLine(rngChar.Text + " " + col.R + "/" + col.G + "/" + col.B);
    
    				if (f.Color != WdColor.wdColorAutomatic) {
    					if (counts.ContainsKey(col))
    						counts[col]++;
    					else
    						counts[col] = 1;
    				}
    
    				Marshal.ReleaseComObject(f);
    				Marshal.ReleaseComObject(rngChar);
    			}
    			Marshal.ReleaseComObject(rng);
    		}
    		sb.AppendLine(String.Format("<tr><td colspan=3>&nbsp;</td></tr>"));
    
    		foreach (Range rng in doc.StoryRanges) {
    			foreach (Range rngWord in rng.Words) { // by each word
    				_Font f = rngWord.Font;
    				int rgb = (int) f.Color;
    				//System.Drawing.Color col = System.Drawing.ColorTranslator.FromOle(rgb);  // do not use - not 1-to-1
    				var col = RgbColorRetriever.GetRGBColor(f.Color, doc);
    				sb.AppendLine(String.Format("<tr><td>{0}</td><td>{1},{2},{3}</td><td bgcolor='{4}'></td></tr>", rngWord.Text, col.R, col.G, col.B, ToHex(col)));
    				//sb.AppendLine(rngWord.Text + " " + col.R + "/" + col.G + "/" + col.B);
    				Marshal.ReleaseComObject(f);
    				Marshal.ReleaseComObject(rngWord);
    			}
    			Marshal.ReleaseComObject(rng);
    		}
    		sb.AppendLine("</table>");
    		sb.AppendLine("</body></html>");
    
    		doc.Close(false);
    		app.Quit(false);
    		Marshal.ReleaseComObject(doc);
    		Marshal.ReleaseComObject(docs);
    		Marshal.ReleaseComObject(app);
    
    		// if there is a tie, then there is the risk that the color will flip back and forth depending on how the dictionary is ordered
    		Color max = counts.Count == 0 ? Color.Black : counts.Aggregate((i1,i2) => i1.Value > i2.Value ? i1 : i2).Key;
    		String html = sb.ToString(); // testing only
    	}
    
    	private static String ToHex(System.Drawing.Color c) {
    		return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
    	}
    }
    
    
    
    
    
    /// <summary>
    /// static class with rgb color retrieving logic: Microsoft.Office.Interop.Word.WdColor -> System.Drawing.Color
    /// </summary>
    public static class RgbColorRetriever {
    	#region Constants
    
    	// first byte of WdColor determines its format type
    	private static readonly int
    		RGB = 0x00,
    		Automatic = 0xFF,
    		System = 0x80,
    		ThemeLow = 0xD0,
    		ThemeHigh = 0xDF;
    
    	//structure to store HSL (hue, saturation, lightness) color
    	private struct HSL {
    		public double H, S, L;
    	}
    
    	#endregion
    
    	/// <summary>
    	/// Get RGB-color from WdColor
    	/// </summary>
    	/// <param name="wdColor">source color</param>
    	/// <param name="doc">document, where this color from (for appropriate color theme)</param>
    	public static Color GetRGBColor(WdColor wdColor, Document doc) {
    		// separate 1st byte (the most significant) and 3 others to different vars
    		int color = ((int) wdColor) & ((int) 0xFFFFFF);
    		int colorType = (int) (((uint) wdColor) >> 24);
    
    		if (colorType == RGB) {
    			// simple color in OLE format (it's just a BGR - blue, green, red) 
    			// let's use standard color translator from system.drawing
    			return ColorTranslator.FromOle(color);
    		}
    		else if (colorType == Automatic) {
    			// standard contrast color. In my case I was needed color. But I don't know the proper way to understand which one (black or white) I need to choose.
    			return Color.White;
    		}
    		else if (colorType == System) {
    			// In ActiveX controls in documents, and in VBA (for UserForm controls, for example) special values for system colours 
    			// (for some reason lost in the mists of time these are also called OLE Colors) ranging from 0x80000000 to 0x80000018. 
    			// I used system dll function to retrieve system color and then used standard color translator
    			int sysColor = GetSysColor(color);
    			return ColorTranslator.FromOle(sysColor);
    		}
    		else if (colorType >= ThemeLow && colorType <= ThemeHigh) {
    			// color based on doc's color theme
    			return GetThemedColor(colorType, color, doc);
    		}
    
    		throw new Exception("Unknown color type");
    	}
    
    	private static Color GetThemedColor(int colorType, int color, Document doc) {
    		// color based on theme is base color + tint or shade
    		double tintAndShade = 0;
    		// base color index is least siginficant 4 bits from colorType
    		int colorThemeIndex = colorType & 0xF;
    
    		// 2nd most significant byte is always 0
    		// 3rd byte - shade, 4th - tint. One of them must be 0xFF and shouldn't be used
    		// it means that always is used one of them and other is 0xFF
    		int darkness = (color & 0x00FF00) >> 8;
    		int lightness = color & 0x0000FF;
    
    		if (darkness != 0xFF)
    			tintAndShade = -1 + darkness / 255.0;
    		else
    			tintAndShade = 1.0 - lightness / 255.0;
    		// so: 
    		//      tintAndShade < 0 => shade base color by |tintAndShade| * 100%
    		//      tintAndShade > 0 => tint base color |tintAndShade| * 100%
    
    		return GetThemedColor(colorThemeIndex, tintAndShade, doc);
    	}
    
    	private static Color GetThemedColor(int colorThemeIndex, double tintAndShade, Document doc) {
    		// translate from wdThemeColorIndex to MsoThemeColorSchemeIndex
    		MsoThemeColorSchemeIndex colorSchemeIndex = ThemeIndexToSchemeIndex(colorThemeIndex);
    		// get color scheme by this index and take its RGB property, but this RGB still OLE RGB - i.e. BGR -> need to convert it to real RGB, i.e. use ColorTranslator.FromOle() and ToArgb after
    		OfficeTheme theme = doc.DocumentTheme;
    		ThemeColorScheme scheme = theme.ThemeColorScheme;
    		ThemeColor color = scheme.Colors(colorSchemeIndex);
    		int colorSchemeRGB = ColorTranslator.FromOle(color.RGB).ToArgb();
    		Marshal.ReleaseComObject(color);
    		Marshal.ReleaseComObject(scheme);
    		Marshal.ReleaseComObject(theme);
    
    		// do RGB -> HSL translation to apply tint/shade
    		HSL colorSchemeHSL = RGBtoHSL(colorSchemeRGB);
    
    		// apply it
    		if (tintAndShade > 0)
    			colorSchemeHSL.L += (1 - colorSchemeHSL.L) * tintAndShade;
    		else
    			colorSchemeHSL.L *= 1 - Math.Abs(tintAndShade);
    
    		// do backward HSL -> RGB translation
    		int tintedAndShadedRGB = HSLtoRGB(colorSchemeHSL);
    
    		return Color.FromArgb(tintedAndShadedRGB);
    	}
    
    	private static int HSLtoRGB(HSL HSL) {
    		// took from https://stackoverflow.com/questions/2353211/hsl-to-rgb-color-conversion
    		double red, green, blue;
    
    		if (HSL.S == 0)
    			red = green = blue = HSL.L;
    		else {
    			double q = HSL.L < 0.5 ? HSL.L * (1 + HSL.S) : HSL.L + HSL.S - HSL.L * HSL.S;
    			double p = 2 * HSL.L - q;
    
    			red = Hue2RGB(p, q, HSL.H + 1.0 / 3);
    			green = Hue2RGB(p, q, HSL.H);
    			blue = Hue2RGB(p, q, HSL.H - 1.0 / 3);
    		}
    
    		int r = (int) (red * 255), g = (int) (green * 255), b = (int) (blue * 255);
    		return (r << 16) + (g << 8) + b;
    	}
    
    	private static double Hue2RGB(double p, double q, double t) {
    		// took from https://stackoverflow.com/questions/2353211/hsl-to-rgb-color-conversion
    
    		if (t < 0) t += 1;
    		if (t > 1) t -= 1;
    		if (t < 1.0 / 6) return p + (q - p) * 6 * t;
    		if (t < 1.0 / 2) return q;
    		if (t < 2.0 / 3) return p + (q - p) * (2.0 / 3 - t) * 6;
    		return p;
    	}
    
    	private static HSL RGBtoHSL(int RGB) {
    		// took from https://stackoverflow.com/questions/2353211/hsl-to-rgb-color-conversion
    		double red, green, blue;
    		double max, min, diff;
    
    		red = ((RGB & 0xFF0000) >> 16) / 255.0;
    		green = ((RGB & 0x00FF00) >> 8) / 255.0;
    		blue = (RGB & 0x0000FF) / 255.0;
    
    		max = Math.Max(red, Math.Max(green, blue));
    		min = Math.Min(red, Math.Min(green, blue));
    		diff = max - min;
    
    		HSL res;
    		res.L = res.H = res.S = (max + min) / 2;
    		if (max == min)
    			res.S = res.H = 0;
    		else {
    			res.S = res.L < 0.5 ? diff / (max + min) : diff / (2 - max - min);
    
    			if (red == max)
    				res.H = (green - blue) / diff - (blue > green ? 6 : 0);
    			else if (green == max)
    				res.H = (blue - red) / diff + 2;
    			else if (blue == max)
    				res.H = (red - green) / diff + 4;
    			res.H /= 6;
    		}
    
    		return res;
    	}
    
    	private static MsoThemeColorSchemeIndex ThemeIndexToSchemeIndex(int colorThemeIndex) {
    		// translation sheet from http://www.wordarticles.com/Articles/Colours/2007.php#UIConsiderations
    		switch ((WdThemeColorIndex) colorThemeIndex) {
    			case WdThemeColorIndex.wdThemeColorMainDark1:
    				return MsoThemeColorSchemeIndex.msoThemeDark1;
    			case WdThemeColorIndex.wdThemeColorMainLight1:
    				return MsoThemeColorSchemeIndex.msoThemeLight1;
    			case WdThemeColorIndex.wdThemeColorMainDark2:
    				return MsoThemeColorSchemeIndex.msoThemeDark2;
    			case WdThemeColorIndex.wdThemeColorMainLight2:
    				return MsoThemeColorSchemeIndex.msoThemeLight2;
    			case WdThemeColorIndex.wdThemeColorAccent1:
    				return MsoThemeColorSchemeIndex.msoThemeAccent1;
    			case WdThemeColorIndex.wdThemeColorAccent2:
    				return MsoThemeColorSchemeIndex.msoThemeAccent2;
    			case WdThemeColorIndex.wdThemeColorAccent3:
    				return MsoThemeColorSchemeIndex.msoThemeAccent3;
    			case WdThemeColorIndex.wdThemeColorAccent4:
    				return MsoThemeColorSchemeIndex.msoThemeAccent4;
    			case WdThemeColorIndex.wdThemeColorAccent5:
    				return MsoThemeColorSchemeIndex.msoThemeAccent5;
    			case WdThemeColorIndex.wdThemeColorAccent6:
    				return MsoThemeColorSchemeIndex.msoThemeAccent6;
    			case WdThemeColorIndex.wdThemeColorHyperlink:
    				return MsoThemeColorSchemeIndex.msoThemeHyperlink;
    			case WdThemeColorIndex.wdThemeColorHyperlinkFollowed:
    				return MsoThemeColorSchemeIndex.msoThemeFollowedHyperlink;
    			case WdThemeColorIndex.wdThemeColorBackground1:
    				return MsoThemeColorSchemeIndex.msoThemeLight1;
    			case WdThemeColorIndex.wdThemeColorText1:
    				return MsoThemeColorSchemeIndex.msoThemeDark1;
    			case WdThemeColorIndex.wdThemeColorBackground2:
    				return MsoThemeColorSchemeIndex.msoThemeLight2;
    			case WdThemeColorIndex.wdThemeColorText2:
    				return MsoThemeColorSchemeIndex.msoThemeDark2;
    			default:
    				throw new Exception("Unknown WdThemeColorIndex: " + colorThemeIndex);
    		}
    	}
    
    	[DllImport("user32.dll", CharSet = CharSet.Auto)]
    	public static extern int GetSysColor(int nIndex);
    }
