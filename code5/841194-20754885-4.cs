    using System;
    
    namespace RepeaterTestOne
    {
        public partial class Show : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    MyDataClass.BindTable(rptDisplay);
                    MyDataClass.BindTable(rptAnother);
                     //You can call BindTable() with any repeater like
                     //MyDataClass.BindTable(MyRepeaterID);
                }
            }
        }
    }
