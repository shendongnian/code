    namespace FormTest
    {
        
    public partial class About : Page
    {
        private int myFirstTableMaxRows = 3;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            tbl.BorderStyle = BorderStyle.Inset;
            tbl.BorderWidth = Unit.Pixel(1);
           
            if (!Page.IsPostBack)
            {
                Session["myFirstTable_count"] = "0";
            }
            else
            {
                int count = (int)Session["myFirstTable_count"];
                Session["myFirstTable_count"] = ++count;
            }
        }
        protected void cmdCreate_Click(object sender, System.EventArgs e)
        {
            tbl.Controls.Clear();
            int cols = 4;
            int currentRowCount = (int)Session["myFirstTable_count"];
            if(currentRowCount <= myFirstTableMaxRows)
            {
                TableRow rowNew = new TableRow();
                tbl.Controls.Add(rowNew);
                for (int j = 0; j < cols; j++)
                {
                    TableCell cellNew = new TableCell();
                    Label lblNew = new Label();
                    lblNew.Text = "(" + i.ToString() + "," + j.ToString() + ")<br />";
                    TextBox tbNew = new TextBox();
                    cellNew.Controls.Add(lblNew);
                    cellNew.Controls.Add(tbNew);
                    rowNew.Controls.Add(cellNew);
                }
            }
            else
            {
                Response.Redirect("http://www.google.co.uk");
            }
             
        }//end cmdCreate_Click
    }
