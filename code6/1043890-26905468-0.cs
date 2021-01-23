    ----------------------------------------------------------------------------------------------------------------------------------
    Page 1 : aspx
     
    
    
        <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>
         
        <!DOCTYPE html>
         
        <html xmlns="http://www.w3.org/1999/xhtml">
        <head runat="server">
            <title></title>
            <script src="jquery.js.js"></script>
            <script type="text/javascript">
         
            </script>
         
    
    </head>
    <body>
        <form id="form1" runat="server">
     
            <table>
                <tr>
                    <td>Last Name</td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Speciality</td>
                    <td>
                        <asp:DropDownList ID="ddlSpeciality" runat="server">
                            <asp:ListItem Text="" />
                            <asp:ListItem Text="aaa" />
                            <asp:ListItem Text="bbb" />
                            <asp:ListItem Text="ccc" />
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Location</td>
                    <td>
                        <asp:DropDownList ID="ddlLocation" runat="server">
                            <asp:ListItem Text="" />
                            <asp:ListItem Text="bangalore" />
                            <asp:ListItem Text="chennai" />
                            <asp:ListItem Text="hyderabad" />
                        </asp:DropDownList></td>
                </tr>
                <tr>
     
                    <td colspan="2" align="center">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
                </tr>
            </table>
     
    
        </form>
    </body>
    </html>
    
     
    
     
    page1 cs file
     
    
    
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
         
        namespace WebApplication1
        {
            public partial class WebForm1 : System.Web.UI.Page
            {
                protected void Page_Load(object sender, EventArgs e)
                {
                }
         
                protected void btnSearch_Click(object sender, EventArgs e)
                {
                    string lastName = txtLastName.Text.Trim();
                    string speciality = ddlSpeciality.Text;
                    string location = ddlLocation.Text;
                    Response.Redirect(string.Format("page2.aspx?lastname={0}&speciality={1}&location={2}",lastName ,speciality , location));
         
        
                }
            }
         
        
        }
        
         
        
         
        
        __________________________________________________________________________________________________________________________
         
        page 2 aspx
         
        
        
        <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page2.aspx.cs" Inherits="WebApplication1.test" %>
         
        <!DOCTYPE html>
         
        <html xmlns="http://www.w3.org/1999/xhtml">
        <head runat="server">
            <title></title>
        </head>
        <body>
            <form id="form1" runat="server">
                <div>
         
                    <asp:GridView ID="gvdata" runat="server">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkID"  OnClick="LinkButton1_Click" Text="Details" runat="server"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
         
        
         
        
                </div>
            </form>
        </body>
        </html>
    
     
    
     
    
     
    page 2 cs file
     
    
    
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
    
     
    
    page3 aspx file
     
    
        <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page3.aspx.cs" Inherits="WebApplication1.page3" %>
         
        <!DOCTYPE html>
         
        <html xmlns="http://www.w3.org/1999/xhtml">
        <head runat="server">
            <title></title>
        </head>
        <body>
            <form id="form1" runat="server">
                <div runat="server" id="divcontent">
                </div>
            </form>
        </body>
        </html>
    
     
    
     
    
    page3 cs file
    
    
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
