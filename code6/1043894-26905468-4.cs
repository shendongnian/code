        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
         
        namespace WebApplication1
        {
            public partial class test : System.Web.UI.Page
            {
                protected void Page_Load(object sender, EventArgs e)
                {
                    if (Page.IsPostBack) { }
                    else
                    {
                        string lastname = Request.QueryString["lastname"];
                        string speciality = Request.QueryString["speciality"];
                        string location = Request.QueryString["location"];
         
                        string query = lastname.Length == 0 ? "" : "lastname ='" + lastname + "' and";
                        query += speciality.Length == 0 ? "" : "speciality ='" + speciality + "' and";
                        query += location.Length == 0 ? "" : "location ='" + location + "' ";
         
                        query = query.Trim().TrimStart(new char[] { 'a', 'n', 'd' }).TrimEnd(new char[] { 'a', 'n', 'd' });
         
                        query = "select * from tablename where " +( query.Length == 0 ? "1=1" : query);
                        // use this query to get data from sql database
                        // use shld get the data from db
                        // for example, i  have hardcoded the datatable with some  values
        
                        DataTable dt = new DataTable();
                        dt.Columns.Add("ID", typeof(int));
                        dt.Columns.Add("lastname", typeof(string));
                        dt.Columns.Add("speciality", typeof(string));
                        dt.Columns.Add("location", typeof(string));
                        dt.Rows.Add(1, "karthik", "aaa", "bangalore");
                        dt.Rows.Add(2, "parthip", "aaa", "chennai");
                        dt.Rows.Add(3, "krishna", "aaa", "hyderabad");
         
        
                        gvdata.DataSource = dt;
                        gvdata.DataBind();
         
        
         
                    }
                }
         
                protected void LinkButton1_Click(object sender, EventArgs e)
                {
                    string id  = ((sender as LinkButton).Parent.Parent as GridViewRow).Cells[1].Text;
                    Response.Redirect("page3.aspx?id=" + id);
                }
            }
        }
    
