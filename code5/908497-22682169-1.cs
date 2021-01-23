    public partial class Tests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindHostelDetails();
            }
        }
        protected void BindHostelDetails()
        {
            gvrecords.DataSource = DBData();
            gvrecords.DataBind();
        }
        protected void gvrecords_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string HostelCode = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "HostelCode"));
                LinkButton lnkbtnresult = (LinkButton)e.Row.FindControl("lnkbtn");
                lnkbtnresult.Text = HostelCode;
            }
        }
        protected void lnkbtn_Click(object sender, EventArgs e) 
        {
            LinkButton lnkbtn = sender as LinkButton;
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            int hostelcode = Convert.ToInt32(gvrecords.DataKeys[gvrow.RowIndex].Value.ToString());
            string HostelName = gvrow.Cells[0].Text;    
            Response.Write("<script> alert('" + "Hostel Name :"+ HostelName +" Hostel Code :"+ hostelcode + "'); </script>");
        }
        List<DTest> DBData()
        {
            List<DTest> _Dt = new List<DTest>();
            _Dt.Add(new DTest { HostelName = "Alpha", HostelCode = "1" });
            _Dt.Add(new DTest { HostelName = "Bravo", HostelCode = "2" });
            _Dt.Add(new DTest { HostelName = "Charlie", HostelCode = "3" });
            return _Dt;
        }
    }
    public class DTest
    {
        public string HostelName { get; set; }
        public string HostelCode { get; set; }
    }
