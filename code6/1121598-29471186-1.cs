    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    
    public partial class logout : System.Web.UI.Page, System.Web.UI.ICallbackEventHandler
    {
        public void RaiseCallbackEvent(string eventArgument)
        {
        }
    
        public string GetCallbackResult()
        {
            return "";
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            ClearAll();
            ClientScriptManager cm = Page.ClientScript;
            string cbReference = cm.GetCallbackEventReference(this, "arg", "HandleResult", "");
            string cbScript = "function CallServer(arg, context){" + cbReference + ";}";
            cm.RegisterClientScriptBlock(this.GetType(), "CallServer", cbScript, true);
            cm.RegisterStartupScript(this.GetType(), "cle", "windows.history.clear", true);
            Response.Redirect("/login.aspx");
    
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            ClearAll();
        }
    
        void ClearAll()
        {
            Session.RemoveAll();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
    
    
        }
    }
