		// System.DateTimeParse
		private static bool ParseByFormat(ref __DTString str, ref __DTString format, ref ParsingInfo parseInfo, DateTimeFormatInfo dtfi, ref DateTimeResult result)
		{	
			...
			case 'M':
				num = format.GetRepeatCount();
				if (num <= 2)
				{
					if (!DateTimeParse.ParseDigits(ref str, num, out newValue2) && (!parseInfo.fCustomNumberParser || !parseInfo.parseNumberDelegate(ref str, num, out newValue2)))
					{
						result.SetFailure(ParseFailureKind.Format, "Format_BadDateTime", null);
						return false;
					}
				}
