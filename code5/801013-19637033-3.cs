     public partial class DynamicControl : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
           
                if (IsPostBack)
                {
                    int num_row = (int)Session["No_of_Rows"];
                    for (int i = 2; i < num_row; i++)
                    {
                        TableRow row = new TableRow();
                        TableCell cell1 = new TableCell();
                        TableCell cell2 = new TableCell();
                        TextBox tb = new TextBox();
                        CheckBox cb = new CheckBox();
    
                        row.ID = "rw" + i;
    
                        cell1.ID = "c" + i + "1";
                        cell2.ID = "c" + i + "2";
    
                        tb.ID = "txt" + i;
                        tb.EnableViewState = true;
                        cb.ID = "chk" + i;
    
                        cell1.Controls.Add(cb);
                        cell2.Controls.Add(tb);
    
                        row.Cells.Add(cell1);
                        row.Cells.Add(cell2);
    
                        tbl.Rows.Add(row);
                    }
                }
                else
                {
                    Session["No_of_Rows"] = 2;
                }
            }
    
            protected void addRow(object sender, EventArgs e)
            {
                int num_row = (int)Session["No_of_Rows"];
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                TextBox tb = new TextBox();
                CheckBox cb = new CheckBox();
    
                row.ID = "rw" + num_row;
    
                cell1.ID = "c" + num_row + "1";
                cell2.ID = "c" + num_row + "2";
    
                tb.ID = "txt" + num_row;
                tb.EnableViewState = true;
                cb.ID = "chk" + num_row;
    
                cell1.Controls.Add(cb);
                cell2.Controls.Add(tb);
    
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
    
                tbl.Rows.Add(row);
                Session["No_of_Rows"] = tbl.Rows.Count;
            }
    
    
            protected void GetValuesfromDynamicControls(object sender, EventArgs e)
            {
                //int rows =Convert.ToInt32( Session["No_of_Rows"]);
                int rows = Convert.ToInt32(tbl.Rows.Count);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < rows; i++)
                {               
                        TextBox tb =(TextBox) Page.FindControl("txt" + i);
                        sb.Append(tb.Text + ";");                
                }
    
                txtOutput.Text = sb.ToString();
            }
    
        }
