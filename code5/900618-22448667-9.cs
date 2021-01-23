    public partial class WebForm1 : System.Web.UI.Page
    {
        string defaultvalue;
        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {
            //DropDownList1.Items.Insert(0, new ListItem("--Select--", ""));
            //DropDownList1.SelectedIndex = 5;
            var itm = DropDownList1.Items.FindByValue(defaultvalue);
            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(itm);
        }
        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            defaultvalue = e.Command.Parameters[0].Value.ToString();
        }
    }
