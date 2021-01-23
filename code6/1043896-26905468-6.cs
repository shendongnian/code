            using System;
            using System.Collections.Generic;
            using System.Data;
            using System.Linq;
            using System.Web;
            using System.Web.UI;
            using System.Web.UI.WebControls;
         
             namespace WebApplication1
            {
            public partial class page3 : System.Web.UI.Page
            {
                protected void Page_Load(object sender, EventArgs e)
                {
                    if (Page.IsPostBack) { }
                    else
                    {
                         string id = Request.QueryString["id"];
                        // use this id to fetch the data from db to get the details.
        
                         // get the data from db..
                        // i have hardcoded
                         DataTable dt = new DataTable();
                         dt.Columns.Add("ID", typeof(int));
                         dt.Columns.Add("lastname", typeof(string));
                         dt.Columns.Add("speciality", typeof(string));
                         dt.Columns.Add("location", typeof(string));
                         dt.Rows.Add(1, "karthik", "aaa", "bangalore");
                         Table tbl = new Table() { CellPadding=1 , CellSpacing=2 , BorderColor = System.Drawing.Color.Red, BorderWidth=1 };
                         
                         foreach (DataColumn col in dt.Columns)
                         {
                             TableRow tr = new TableRow() { BorderWidth=1 , BorderColor = System.Drawing.Color.Red };
                             tr.Cells.Add( new TableCell () { BorderWidth=1 , BorderColor = System.Drawing.Color.Red ,Text = col.ColumnName});
                             tr.Cells.Add( new TableCell () { BorderWidth=1 , BorderColor = System.Drawing.Color.Red ,Text = dt.Rows[0][col].ToString()});
                             tbl.Rows.Add(tr);
         
                            }
         
                         divcontent.Controls.Add(tbl);
                         }
         
        
                    
                }
            }
        }
