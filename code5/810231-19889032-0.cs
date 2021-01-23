    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string item=DropDownList.SelectedItem;
        Session["selectedItem"]=item;
        Response.Redirect("TheNextPageURL")
    }
    public partial class TheNextPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["selectedItem"]!=null)
            {
                Label1.Text=Session["selectedItem"].toString();
            }
        }
    }
