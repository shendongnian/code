    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    
    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("EmployeeID"), new DataColumn("FirstName"), new DataColumn("LastName") });
                dt.Rows.Add("1", "James", "Elgar");
                dt.Rows.Add("2", "Natasha", "Oliver");
                dt.Rows.Add("3", "Stein", "Sektnan");
                dt.Rows.Add("4", "Chris", "Massen");
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            getSelectRows();
        }
        public void getSelectRows()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("EmployeeID"), new DataColumn("FirstName"), new DataColumn("LastName") });
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[3].FindControl("CheckBox1") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string EmployeeID = row.Cells[0].Text;
                        string FirstName = row.Cells[1].Text;
                        string LastName = row.Cells[2].Text;
                        dt.Rows.Add(EmployeeID, FirstName, LastName);
                    }
                }
            }
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
    }
