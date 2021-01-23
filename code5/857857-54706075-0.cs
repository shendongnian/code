    <%@ Import Namespace="System" %>
    <%@ Import Namespace="System.Collections.Generic" %>
    <%@ Import Namespace="System.Linq" %>
    <%@ Import Namespace="System.Web" %>
    <%@ Import Namespace="System.Web.UI" %>
    <%@ Import Namespace="System.Web.UI.WebControls" %>
    <%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>
    <%@ Import Namespace="Newtonsoft.Json" %>
    
    
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
    <html xmlns="http://www.w3.org/1999/xhtml">
    
        
    <head runat="server">
        <title></title>
        <script type="text/javascript" src="jquery-1.10.2.min.js"></script>
    
        <script type="text/javascript">
           
            function CallMethod()
            {
                debugger;
               
    
                    jQuery.ajax({
    
                        url: 'Default.aspx/yourmethod',
                        type: "GET",
                        contentType: "application/json; charset=utf-8",
                        dataType: 'json',
                        data: JSON.stringify({}), // parameters for method
                        success: function (dt)
                        {
                            debugger;
                            alert('success : ' + dt.d  );
    
                        }, //all Ok
                        error: function (dt) {
                            debugger;
                            alert('error : ' + dt);
                        } // some error
    
                    });
          
    
            }
    
            function GreetingsFromServer()
            {
                PageMethods.yourmethod1(OnSuccess, OnError);
            }
            function OnSuccess(response)
            {
                debugger;
                alert(response);
            }
            function OnError(error) {
                alert(error);
            }
    
    
        </script>
    
    
    <script language="C#" runat="server">
    
        [System.Web.Services.WebMethod(EnableSession = true)]  
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static string yourmethod()
        {
            var settings = new Microsoft.AspNet.FriendlyUrls.FriendlyUrlSettings();
            settings.AutoRedirectMode = Microsoft.AspNet.FriendlyUrls.RedirectMode.Off;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject("Allow user");
            return json;
        }
    
    
         [System.Web.Services.WebMethod(EnableSession = true)]  
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
          public static string yourmethod1()
        {
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject("Allow user");
            // or
            return "Allow user";
        }
       
    
        </script>
    </head>
    <body>
        <form id="form1" runat="server" >
            <div>
    
                <asp:ScriptManager runat="server" EnablePageMethods="true"  EnablePartialRendering="true"  > </asp:ScriptManager>
                <input id="Button1" type="button" value="button" onclick="return GreetingsFromServer();" />
                 <input id="Button2" type="button" value="button" onclick="return CallMethod();" />
            </div>
        </form>
    </body>
    </html>
