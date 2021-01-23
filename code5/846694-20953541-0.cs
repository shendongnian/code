    public static void setCheckBoxStates(CheckBoxList cbl)
    		{
    			// if we are postback and using mono
    			if (HttpContext.Current.Request.HttpMethod == "POST"  && Type.GetType("Mono.Runtime") != null)
    			{
    				string cblFormID = cbl.ClientID.Replace("_","$");
    				int i = 0;
    				foreach (var item in cbl.Items)
    				{
    					string itemSelected = HttpContext.Current.Request.Form[cblFormID + "$" + i];
    					if (itemSelected != null && itemSelected != String.Empty)
    						((ListItem)item).Selected = true;
    					i++;
    				}
    			}
    		}
