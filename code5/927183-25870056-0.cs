		private string UrlEncode(string value)
		{
			string unreserved = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
			StringBuilder result = new StringBuilder();
			foreach (char symbol in value)
			{
				if (unreserved.IndexOf(symbol) != -1)
					result.Append(symbol);
				else
					result.Append('%' + String.Format("{0:X2}", (int)symbol));
			}
			return result.ToString();
		}
