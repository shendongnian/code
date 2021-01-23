        public partial class Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                FillDropDownList(drpTest);
    
                // select False after filling drop down list
                drpTest.Items.FindByValue("False").Selected = true;
            }
    
            public static void FillDropDownList(ListControl drp)
            {
                drp.Items.Clear();
                drp.Items.Add(new ListItem("Please select", ""));
                drp.Items.Add(new ListItem("False", false.ToString()));
                drp.Items.Add(new ListItem("True", true.ToString()));
            }
        }
