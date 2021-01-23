		// System.DateTimeParse
		internal static bool ParseDigits(ref __DTString str, int minDigitLen, int maxDigitLen, out int result)
		{
			result = 0;
			int index = str.Index;
			int i;
			for (i = 0; i < maxDigitLen; i++)
			{
				if (!str.GetNextDigit())
				{
					str.Index--;
					break;
				}
				result = result * 10 + str.GetDigit();
			}
			if (i < minDigitLen)
			{
				str.Index = index;
				return false;
			}
			return true;
		}
