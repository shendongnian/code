    public static void DisplayAll<TEnum>(Object obj, string[] aMessage) where TEnum : struct,  IComparable, IFormattable, IConvertible
    /* 
     * see https://stackoverflow.com/questions/28168982/generically-populate-different-classes-members
     * 
     */
    {
	try
	{
		// get the type of wsSoapBody
		Type type = obj.GetType();
		PropertyInfo[] properties = type.GetProperties();
		foreach (PropertyInfo property in properties)
		{
		try
		{
			if (Enum.IsDefined(typeof(TEnum), property.Name))
			{
			TEnum t = (TEnum)Enum.Parse(typeof(TEnum), property.Name, true);
			System.Diagnostics.Debug.WriteLine("Name: " + property.Name + ", Value: " + property.GetValue(obj, null) + "Type: " + property.PropertyType);
			// property.GetValue(obj, null).ToString() != "" &&
			if ( t.ToInt32(Thread.CurrentThread.CurrentCulture) < aMessage.GetUpperBound(0) && aMessage[t.ToInt32(Thread.CurrentThread.CurrentCulture)].ToString() != "")
			{
				switch (property.PropertyType.ToString())
				{
				case "System.String":
					string value = aMessage[t.ToInt32(Thread.CurrentThread.CurrentCulture)].ToString();
					property.SetValue(obj, value, null);
					break;
				case "System.Int32":
					int iValue = Convert.ToInt32(aMessage[t.ToInt32(Thread.CurrentThread.CurrentCulture)].ToString());
					property.SetValue(obj, iValue, null);
					break;
				case "System.Int64":
					long lValue = Convert.ToInt64(aMessage[t.ToInt32(Thread.CurrentThread.CurrentCulture)].ToString());
					property.SetValue(obj, lValue, null);
					break;
				case "System.DateTime":
					DateTime dtValue = DateTime.ParseExact(aMessage[t.ToInt32(Thread.CurrentThread.CurrentCulture)].ToString(), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
					property.SetValue(obj, dtValue, null);
					break;
				default:
					System.Diagnostics.Debugger.Break();
					break;
				}
			}
			else
			{
				logBuilder("Common.DisplayAll", "Info", "", property.Name + " is empty or outside range", "Index number: " + t.ToInt32(Thread.CurrentThread.CurrentCulture).ToString());
				System.Diagnostics.Debug.WriteLine(property.Name + " is empty or outside range", "Index number: " + t.ToInt32(Thread.CurrentThread.CurrentCulture).ToString());
			}
		}
		else
		{
			logBuilder("Common.DisplayAll", "Info", "", property.Name + " is not defined in Enum", "");
			System.Diagnostics.Debug.WriteLine(property.Name + " is not defined in Enum");
		}
		}
		catch (Exception ex)
		{
			logBuilder("Common.DisplayAll", "Error", "", ex.Message, "");
			emailer.exceptionEmail(ex);
			System.Diagnostics.Debugger.Break();
		}
		System.Diagnostics.Debug.WriteLine("Name: " + property.Name + ", Value: " + property.GetValue(obj, null));
		}
	}
	catch (Exception ex)
	{
		logBuilder("Common.DisplayAll", "Error", "", ex.Message, "");
		emailer.exceptionEmail(ex);
		System.Diagnostics.Debugger.Break();
		//throw;
	}
	return;
    }
