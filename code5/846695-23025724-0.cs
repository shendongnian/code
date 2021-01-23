    namespace YOURNAMESPACE.Controls
    {
    	using System.Text.RegularExpressions;
    	using System;
    	using System.Web;
    	using WebControls = System.Web.UI.WebControls;
    
    	public class CheckBoxList : WebControls.CheckBoxList
    	{
    		protected override void OnLoad(EventArgs e)
    		{
    			base.OnLoad(e);
    
    			if (HttpContext.Current.Request.HttpMethod == "POST" && Type.GetType("Mono.Runtime") != null) {
    
    				string cblFormID = Regex.Replace(ClientID, @"_\d+$", String.Empty).Replace("_", "$");
    
    				int i = 0;
    				foreach (WebControls.ListItem item in Items)
    					item.Selected = HttpContext.Current.Request.Form[cblFormID + "$" + i++] == item.Value;
    			}
    		}
    	}
    }
