    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace Practice_Web
    {
        public partial class WebForm2 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                //This is just to simulate the condition part of the original code
                if (Session["condition"] == null)
                    Session["condition"] = false;
                else
                    Session["condition"] = !Convert.ToBoolean(Session["condition"]);
            }
            protected void btnPlay(object sender, EventArgs e)
            {
                bool condition = Convert.ToBoolean(Session["condition"]);
                if (condition)
                {
                    ScriptManager.RegisterStartupScript(upPlayBtn, upPlayBtn.GetType(), "tabs", "OpenPlayerWindow();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upPlayBtn, upPlayBtn.GetType(), "tabs", "OpenPlayerWindowForError();", true);
                }
            }
        }
    }
