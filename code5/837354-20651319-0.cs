	if (xElementAltItem != null)
	{
		if (xElementAltItem.Value.Trim() == "null")
		{
			if (generalstatuscode.Contains(currentstatuscode))
			{
				statuscodeToSet = "1";
				if (xElementupdateDate != null)
				{
					if (xElementupdateDate.Value == "01-JAN-2099")
					{
						statuscodeToSet = "2";
					}
					if (xElementupdateDate.Value != "01-JAN-2099")
					{
						statuscodeToSet = "3";
					}
				}
			}
			if ((currentstatuscode == "Act-NotOrd"))
			{
				statuscodeToSet = "5";
			}
		}
		else
		{
			if (generalstatuscode.Contains(currentstatuscode))
			{
				statuscodeToSet = "4";
			} 
		}
	}
