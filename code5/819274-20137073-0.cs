    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var myList = new List<string>() { "one", "two", "three" };
            myRepeater.DataSource = myList;
            myRepeater.DataBind();
        }
    
        public void R1_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            var items = (string)e.Item.DataItem;
            var newcontrol = (WebUserControl1)Page.LoadControl("~/WebUserControl1.ascx");
            newcontrol.myTest = items;
            myRepeater.Controls.Add(newcontrol);           
        }   
    }
