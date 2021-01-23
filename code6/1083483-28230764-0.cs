    public string FormatValue(double d, int noOfDigits)
		{
			double abs = Math.Abs(d);
			int left = abs < 1 ? 1 : (int)(Math.Log10(abs) + 1);
			int usedDigits = 0;
			StringBuilder sb = new StringBuilder();
			for(; usedDigits < left; usedDigits++)
			{
				sb.Append("0");
			}
			if(usedDigits < noOfDigits)
			{
				sb.Append(".");
				for(; usedDigits < noOfDigits; usedDigits++)
				{
					sb.Append("0");
				}
			}
			return d.ToString(sb.ToString());
		}
