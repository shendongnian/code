	for (int i = 1; i <= 7; i++)
	{
		if (breakfastDays.Contains(i.ToString())
		{
			sb.Append("<td class=\"active\">&nbsp;</td>"));
		}
		else
		{
			sb.Append("<td>&nbsp;</td>");
		}
	}
