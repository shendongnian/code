       <%@ Page Title="Home Page" Language="C#" AutoEventWireup="true"
        CodeFile="Default.aspx.cs" Inherits="_Default" %>
    
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>ASP.NET Prevent Previous Month Selection - Demo</title>
    </head>
    <body>
        <form id="form1" runat="server">
        <div>
        <asp:Calendar ID="someCalendar" runat="server"
    	 OnVisibleMonthChanged="theVisibleMonthChanged" />
        </div>
        </form>
    </body>
    </html>
    
    
    
    
    And the C# code for my demo is:
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    /// <summary>
    /// Demo to show how one might prevent the user from selecting 
    /// the previous month in ASP.NET
    /// 
    /// References: 
    /// [1] - http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.calendar.visiblemonthchanged.aspx
    /// [2] - http://msdn.microsoft.com/en-us/library/8kb3ddd4.aspx
    /// </summary>
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // How to attach visibleMonthChanged event is explained in [1]
    		someCalendar.VisibleMonthChanged +=
    			new MonthChangedEventHandler(this.theVisibleMonthChanged);
        }
    
    	protected void theVisibleMonthChanged(Object sender, MonthChangedEventArgs e) 
    	{
    		DateTime currentDate = DateTime.Now;
    		DateTime dateOfMonthToDisable = currentDate.AddMonths(-1);
    		if (e.NewDate.Month == dateOfMonthToDisable.Month)
    		{
    			someCalendar.VisibleDate = e.PreviousDate;
    			// Custom date formats are explained in [2] 
    			Page.ClientScript.RegisterClientScriptBlock(
    				this.GetType(), 
    				"someScriptKey",
    				"<script>" + 
    				"alert(\"Can not go before today's month of " +
    				currentDate.ToString("MMM-yyyy") +
    				".\");" + 
    				"</script>"
    			);
    		}
    	}
    }
