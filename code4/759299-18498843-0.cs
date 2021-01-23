    <%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
    
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
    <%@ Import Namespace="Google.GData.Client" %>
    <%@ Import Namespace="Google.GData.Extensions" %>
    <%@ Import Namespace="Google.GData.Calendar" %>
    <%@ Import Namespace="System.Net" %>
    
    <script runat="server">
        void PrintCalendar() {
    
            GAuthSubRequestFactory authFactory = new GAuthSubRequestFactory("cl", "TesterApp");
            authFactory.Token = (String) Session["token"];
            CalendarService service = new CalendarService(authFactory.ApplicationName);
            service.RequestFactory = authFactory;
    
            EventQuery query = new EventQuery();
    
            query.Uri = new Uri("http://www.google.com/calendar/feeds/default/private/full");
    
            try
            {
                EventFeed calFeed = service.Query(query);
                foreach (Google.GData.Calendar.EventEntry entry in calFeed.Entries)
                {
                    Response.Write("Event: " + entry.Title.Text + "<br/>");
                }
            }
            catch (GDataRequestException gdre)
            {
                HttpWebResponse response = (HttpWebResponse)gdre.Response;
                
                //bad auth token, clear session and refresh the page
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    Session.Clear();
                    Response.Redirect(Request.Url.AbsolutePath, true);
                }
                else
                {
                    Response.Write("Error processing request: " + gdre.ToString());
                }
            }
        }
    
    </script>
    
    
    <html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Test Site</title>
    </head>
    <body>
    
        <form id="form1" runat="server">
        <h1>AuthSub Sample Page</h1>
        <div>
        <%
            GotoAuthSubLink.Visible = false;
            
            if (Session["token"] != null)
            {
                PrintCalendar();
            }
            else if (Request.QueryString["token"] != null)
            {
                String token = Request.QueryString["token"];
                Session["token"] = AuthSubUtil.exchangeForSessionToken(token, null).ToString();
                Response.Redirect(Request.Url.AbsolutePath, true);
            }
            else //no auth data, print link
            {
                GotoAuthSubLink.Text = "Login to your Google Account";
                GotoAuthSubLink.Visible = true;
                GotoAuthSubLink.NavigateUrl = AuthSubUtil.getRequestUrl(Request.Url.ToString(),
                    "http://www.google.com/calendar/feeds/",false,true);
            }
            
         %>
        <asp:HyperLink ID="GotoAuthSubLink" runat="server"/>
    
        </div>
        </form>
    </body>
    </html>
