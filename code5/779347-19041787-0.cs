    <%@ Page Language="C#" AutoEventWireup="true"%>
    <%@ Import Namespace="System" %>
    <%@ Import Namespace="System.Data" %>
    <%@ Import Namespace="System.Data.Sql" %>
    <%@ Import Namespace="System.Drawing" %>
    
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            //Doing the binding when the page is loading for the first time (not on postbacks)
            if (!IsPostBack)
            {
                //Test datasource (Creating a datatable with 10 columns. Then adding 3 rows. cell indeces are 0 based.)
                
                DataTable dt = new DataTable();
                
                DataColumn dc1 = new DataColumn("col1");
                DataColumn dc2 = new DataColumn("col2");
                DataColumn dc3 = new DataColumn("col3");
                DataColumn dc4 = new DataColumn("col4");
                DataColumn dc5 = new DataColumn("col5");
                DataColumn dc6 = new DataColumn("col6");
                DataColumn dc7 = new DataColumn("col7");
                DataColumn dc8 = new DataColumn("col8");
                DataColumn dc9 = new DataColumn("col9");
                DataColumn dc10 = new DataColumn("col10");
                
                dt.Columns.Add(dc1);
                dt.Columns.Add(dc2);
                dt.Columns.Add(dc3);
                dt.Columns.Add(dc4);
                dt.Columns.Add(dc5);
                dt.Columns.Add(dc6);
                dt.Columns.Add(dc7);
                dt.Columns.Add(dc8);
                dt.Columns.Add(dc9);
                dt.Columns.Add(dc10);
    
                //Second row index 9 has "Missing" as the text
                dt.Rows.Add(new object[] { "cell1", "cell2", "cell3", "cell4", "cell5", "cell6", "cell7", "cell8", "cell9", "cell10" });
                dt.Rows.Add(new object[] { "cell1", "cell2", "cell3", "cell4", "cell5", "cell6", "cell7", "cell8", "cell9", "Missing" });
                dt.Rows.Add(new object[] { "cell1", "cell2", "cell3", "cell4", "cell5", "cell6", "cell7", "cell8", "cell9", "cell10" });
                
                //Set datasource. Then bind it. (here the grid is using auto generated columns)
                SYSGrid.DataSource = dt;
                SYSGrid.DataBind();
            }
        }
    
        protected void SYSGrid_RowDataBound(object sender, GridViewRowEventArgs e)    
        {
           if (e.Row.RowType == DataControlRowType.DataRow)
           {
              if (e.Row.Cells[9].Text == "Missing")
              {
                  e.Row.Cells[9].BackColor = Color.Red;
                  e.Row.Cells[9].ForeColor = Color.White;
               }
            }
        }
    </script>
    
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
        <div>    
            <asp:gridview runat="server" ID="SYSGrid" OnRowDataBound="SYSGrid_RowDataBound"></asp:gridview>
        </div>
        </form>
    </body>
    </html>
