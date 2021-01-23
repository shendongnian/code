    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using System.Data;
    using System.Data.OleDb;
    using System.Configuration;
    using System.Web.UI.HtmlControls;
    using System.Xml.Linq;
    namespace Travel1.Forms
    {
        public partial class temporaryduty : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                Lbltoday.Text = DateTime.Now.ToString();
                if (!IsPostBack)
                {
                    GetName();//adding the group to the dropdownbox
                }
            }
         private void GetName()
         {
             using (SqlConnection conn = new SqlConnection("Server; Database; Integrated security = true"))
             using (SqlCommand cmd = new SqlCommand("Select EMPID,Name FROM M_employee where IsActive=1 ORDER BY Name", conn))
             using (DataSet objDs = new DataSet())
             using (SqlDataAdapter sd = new SqlDataAdapter(cmd))
             {
                 conn.Open();
                 sd.Fill(objDs);
                 if (objDs.Tables[0].Rows.Count > 0)
                 {
                    ddlname.DataSource = objDs.Tables[0];
                    ddlname.DataTextField = "Name";
                    ddlname.DataValueField = "EMPID";
                    ddlname.DataBind();
                    ddlname.Items.Insert(0, "--Select--");
                 }
             }
         }
         protected void ddlname_SelectedIndexChanged(object sender, EventArgs e)
         {
             GetDivision(ddlname.SelectedItem.Value);
         }
         private void GetDivision(string Name)
         {
             using (SqlConnection conn = new SqlConnection("Server; Database; Integrated security = true"))
             using (SqlCommand cmd = new SqlCommand("SELECT M_employee.Name, M_Division.DIVISION, M_Division.DIVID AS Expr1, M_Designation.DesigID AS Expr2, M_Designation.Designation FROM M_employee INNER JOIN M_Division ON M_employee.DIVID = M_Division.DIVID INNER JOIN M_Designation ON M_employee.DesigID = M_Designation.DesigID WHERE M_employee.EMPID=@EMPID ", conn))
             using (DataSet objDs = new DataSet())
             using (SqlDataAdapter sd = new SqlDataAdapter(cmd))
             {
                 cmd.Parameters.AddWithValue("@EMPID", Name);
                 conn.Open();
                 sd.Fill(objDs);
                 if (objDs.Tables[0].Rows.Count > 0)
                 {
                     lbldiv.Text = objDs.Tables[0].Rows[0]["DIVISION"].ToString();
                     lbldesig.Text = objDs.Tables[0].Rows[0]["Designation"].ToString();
                 }
             }
         }
        protected void btnSubmit_Click2(object sender, EventArgs e)
        {
            string RelaseDate = Calendar1.SelectedDate.Date.ToString();
            int cnt;
            using (SqlConnection conn = new SqlConnection("Server; Database; Integrated security = true"))
            using (SqlCommand cmd = new SqlCommand("Insert into T_TADA_tempform(EMPID,DIVID,DesigID) values(@EMPID,@DIVID,@DesigID)", conn))
            {
                cmd.Parameters.AddWithValue("@EMPID", ddlname.SelectedValue);
                cmd.Parameters.AddWithValue("@DIVID", lbldesig.Text);
                cmd.Parameters.AddWithValue("@DesigID", lbldiv.Text);
                conn.Open();
                cnt = cmd.ExecuteNonQuery();
            }
            if (cnt == 1)
                {
                    Response.Redirect("form.aspx");
                }
                else
                    Response.Write("Form has not been submitted,Please Try again!");
            }
        }
        }
