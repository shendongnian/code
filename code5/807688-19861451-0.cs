    public void AverageColorTest_WebExample_FineTuned()
	{                
		Bitmap bm = new Bitmap("C:\\Users\\XXX\\Desktop\\example1.jpg");
		int width = bm.Width;
		int height = bm.Height;
		int red = 0;
		int green = 0;
		int blue = 0;
		float minDiversion = 30 / 100; // drop pixels that do not differ by at least minDiversion between color values (white, gray or black)
		int dropped = 0; // keep track of dropped pixels                
		int bppModifier = bm.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb ? 3 : 4; // cutting corners, will fail on anything else but 32 and 24 bit images
		BitmapData srcData = bm.LockBits(new System.Drawing.Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadOnly, bm.PixelFormat);
		int stride = srcData.Stride;
		IntPtr Scan0 = srcData.Scan0;
		Dictionary<Color, Int64> dicColors = new Dictionary<Color, long>(); // color, pixelcount i.e ('#FFFFFF',100);
		unsafe
		{
		    byte* p = (byte*)(void*)Scan0;
		    for (int y = 0; y < height; y++)
		    {
				for (int x = 0; x < width; x++)
				{
				    int idx = (y * stride) + x * bppModifier;
				    red = p[idx + 2];
				    green = p[idx + 1];
				    blue = p[idx];
				    if (red == 255 && green == 255 && blue == 255)
					continue;
				    
				    Color GroupedColor = GetNamedWebColor_NearestMatch(red, green, blue);
				    
				    if (dicColors.ContainsKey(GroupedColor))
				    {
					    dicColors[GroupedColor]++;
				    }
				    else
				    {
					    dicColors.Add(GroupedColor, 1);
				    }
				}
		    }
		}
		// sort dictionary of colors so that most used is at top
		dicColors = dicColors.OrderByDescending(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
		List<Color> MainColors  = null;
		Int16 numberOf          = 3;
		float minHueDiff        = (float)10;
		float minBrightDiff     = (float)0.1;
		float minSatDiff        = (float)0.1;
		MainColors = GetMainXColors(dicColors.Keys.ToList(), numberOf, minHueDiff, minBrightDiff, minSatDiff);
		foreach (Color MainColor in MainColors)
		{
		    Console.WriteLine(ColorTranslator.ToHtml(MainColor)); // should ouput main colors
		}
	}	
	/// <summary>
	/// returns first x many colors that differ by min HSL properties passed in
	/// </summary>
	/// <param name="listIn"></param>
	/// <param name="ReturnMaxNumberOfColors"></param>
	/// <param name="minHueDiff"></param>
	/// <param name="minBrightDiff"></param>
	/// <param name="minSatDiff"></param>
	/// <returns></returns>
	private static List<Color> GetMainXColors(List<Color> listIn, Int32 ReturnMaxNumberOfColors, float minHueDiff, float minBrightDiff, float minSatDiff)
	{
		List<Color> response = new List<Color>();
		Int32 i = 0;
		while (response.Count < ReturnMaxNumberOfColors && i < listIn.Count)
		{
		    bool  blnUniqueMainColor = true; // want main colors ie dark brown, gold, silver, not 3 shades of brown
		    Color nextColor          = listIn[i];
		    float brightness    = nextColor.GetBrightness();
		    float sat           = nextColor.GetSaturation();
		    float hue           = nextColor.GetHue();
		    for (Int32 j = 0; j < response.Count; j++)
		    {
				float brightnessOther   = response[j].GetBrightness();
				float satOther          = response[j].GetSaturation();
				float hueOther          = response[j].GetHue();
				// hue is 360 degrees of color, to calculate hue difference                        
				// need to subtract 360 when either are out by 180 (i.e red is at 0 and 359, diff should be 1 etc)
				if (hue - hueOther > 180) hue -= 360;
				if (hueOther - hue > 180) hueOther -= 360;
				float brightdiff        = Math.Abs(brightness - brightnessOther);
				float satdiff           = Math.Abs(sat - satOther);
				float huediff           = Math.Abs(hue - hueOther);
				int matchHSL            = 0;
				if (brightdiff <= minBrightDiff)
				    matchHSL++;
				if (satdiff <= minSatDiff)
				    matchHSL++;
				if (huediff <= minHueDiff) 
				    matchHSL++;
				if (matchHSL != 0  & satdiff != 1))
				{
				    blnUniqueMainColor = false;
				    break;
				}
		    }
		    if (blnUniqueMainColor)
		    {		// color differs by min ammount of HSL so add to response
				response.Add(nextColor);
		    }
		    i++;
		}
		return response;
	}	
	private static List<Color> WebColors;
	/// <summary>
	/// Returns the "nearest" color from a given "color space"
	/// </summary>
	/// <param name="input_color">The color to be approximated</param>
	/// <returns>The nearest color</returns>        
	public static Color GetNamedWebColor_NearestMatch(double dbl_input_red, double dbl_input_green, double dbl_input_blue)
	{
	    // get the colorspace as an ArrayList
	    if (WebColors == null) 
		    WebColors = GetWebColors();
	    // the Euclidean distance to be computed
	    // set this to an arbitrary number
	    // must be greater than the largest possible distance (appr. 441.7)
	    double distance = 500.0;
	    // store the interim result
	    double temp;
	    // RGB-Values of test colors
	    double dbl_test_red;
	    double dbl_test_green;
	    double dbl_test_blue;
	    // initialize the result
	    Color nearest_color = Color.Empty;
	    foreach (Color o in WebColors)
	    {
			// compute the Euclidean distance between the two colors
			// note, that the alpha-component is not used in this example                
			dbl_test_red    = Math.Pow(Convert.ToDouble(((Color)o).R) - dbl_input_red, 2.0);
			dbl_test_green  = Math.Pow(Convert.ToDouble(((Color)o).G) - dbl_input_green, 2.0);
			dbl_test_blue   = Math.Pow(Convert.ToDouble(((Color)o).B) - dbl_input_blue, 2.0);
			temp            = Math.Sqrt(dbl_test_blue + dbl_test_green + dbl_test_red);
			// explore the result and store the nearest color
			if (temp < distance)
			{
			    distance = temp;
			    nearest_color = (Color)o;
			}
	    }            
	    return nearest_color;
	}
	/// <summary>
	/// Returns an ArrayList filled with "WebColors"
	/// </summary>
	/// <returns>WebColors</returns>
	/// <remarks></remarks>
	private static List<Color> GetWebColors()
	{
	    List<string> listIgnore = new List<string>();
	    listIgnore.Add("transparent");
	    Type color = (typeof(Color));
	    PropertyInfo[] propertyInfos = color.GetProperties(BindingFlags.Public | BindingFlags.Static);
	    List<Color> colors = new List<Color>();
	    foreach (PropertyInfo pi in propertyInfos)
	    {
		    if (pi.PropertyType.Equals(typeof(Color)))
		    {
		        Color c = (Color)pi.GetValue((object)(typeof(Color)), null);
		        if (listIgnore.Contains(c.Name.ToLower()))
			    continue;
		        colors.Add(c);
		    }
	    }
	    return colors;
	}
