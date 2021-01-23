    code in .aspx
    
    
    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="Customer.Customer" %>
    
    <html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
    .Gridview
    {
    font-family:Verdana;
    font-size:10pt;
    font-weight:normal;
    color:black;
    }
    </style>
        <script type="text/javascript">
            function ConfirmationBox(username) {
    
                var result = confirm('Are you sure you want to delete ' + username + ' Details?');
                if (result) {
    
                    return true;
                }
                else {
                    return false;
                }
            }
    </script>
    </head>
    <body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="gvDetails" DataKeyNames="UserId" runat="server"
    AutoGenerateColumns="False" CssClass="Gridview" HeaderStyle-BackColor="#61A6F8"
    ShowFooter="True" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
    onrowcancelingedit="gvDetails_RowCancelingEdit"
    onrowdeleting="gvDetails_RowDeleting" onrowediting="gvDetails_RowEditing"
    onrowupdating="gvDetails_RowUpdating"
    onrowcommand="gvDetails_RowCommand">
    <Columns>
    <asp:TemplateField>
    <EditItemTemplate>
    <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/Images/update.jpg" ToolTip="Update" Height="20px" Width="20px" />
    <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/Images/Cancel.jpg" ToolTip="Cancel" Height="20px" Width="20px" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="~/Images/Edit.jpg" ToolTip="Edit" Height="20px" Width="20px" />
    <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server" ImageUrl="~/Images/delete.jpg" ToolTip="Delete" Height="20px" Width="20px" />
    </ItemTemplate>
    <FooterTemplate>
    <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="~/Images/AddNewitem.jpg" CommandName="AddNew" Width="30px" Height="30px" ToolTip="Add new User" ValidationGroup="validaiton" />
    </FooterTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="UserName">
    <EditItemTemplate>
    <asp:TextBox ID="txtusername" runat="server" Text='<%#Eval("Username") %>'/>
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="lblitemUsr" runat="server" Text='<%#Eval("UserName") %>'/>
    </ItemTemplate>
    <FooterTemplate>
    <asp:TextBox ID="txtftrusrname" runat="server"/>
    <asp:RequiredFieldValidator ID="rfvusername" runat="server" ControlToValidate="txtftrusrname" Text="*" ValidationGroup="validaiton"/>
    </FooterTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="City">
    <EditItemTemplate>
    <asp:TextBox ID="txtcity" runat="server" Text='<%#Eval("City") %>'/>
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="lblcity" runat="server" Text='<%#Eval("City") %>'/>
    </ItemTemplate>
    <FooterTemplate>
    <asp:TextBox ID="txtftrcity" runat="server"/>
    
    </FooterTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Designation">
    <EditItemTemplate>
    <asp:TextBox ID="txtDesg" runat="server" Text='<%#Eval("Designation") %>'/>
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="lblDesg" runat="server" Text='<%#Eval("Designation") %>'/>
    </ItemTemplate>
    <FooterTemplate>
    <asp:TextBox ID="txtftrDesignation" runat="server"/>
    <asp:RequiredFieldValidator ID="rfvdesignation" runat="server" ControlToValidate="txtftrDesignation" Text="*" ValidationGroup="validaiton"/>
    </FooterTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
    </div>
    <div>
    <asp:Label ID="lblresult" runat="server"></asp:Label>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    </form>
    </body>
    </html>
    
    
    c# code
    
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BEL;
    using BLL;
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration;
    using System.Drawing;
    
    namespace Customer
    {
        public partial class Customer : System.Web.UI.Page
        {
            SqlConnection con = new SqlConnection(@"Data Source=PRASHANTH1\SQLSERVER2012;Integrated Security=true;Initial Catalog=emp");
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    BindEmployeeDetails();
                }
            }
            protected void BindEmployeeDetails()
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Employee_Details", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvDetails.DataSource = ds;
                    gvDetails.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    gvDetails.DataSource = ds;
                    gvDetails.DataBind();
                    int columncount = gvDetails.Rows[0].Cells.Count;
                    gvDetails.Rows[0].Cells.Clear();
                    gvDetails.Rows[0].Cells.Add(new TableCell());
                    gvDetails.Rows[0].Cells[0].ColumnSpan = columncount;
                    gvDetails.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
            protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
            {
                gvDetails.EditIndex = e.NewEditIndex;
                BindEmployeeDetails();
            }
            protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
                int userid = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Value.ToString());
                //string username = gvDetails.DataKeys[e.RowIndex].Values["UserName"].ToString();
                TextBox txtusername = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtusername");
                TextBox txtcity = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtcity");
                TextBox txtDesignation = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtDesg");
                con.Open();
                SqlCommand cmd = new SqlCommand("update Employee_Details set City='" + txtcity.Text + "',Designation='" + txtDesignation.Text + "',UserName='" + txtusername.Text + "'  where UserId=" + userid, con);
                cmd.ExecuteNonQuery();
                con.Close();
                lblresult.ForeColor = Color.Green;
                lblresult.Text = txtusername.Text  + " Details Updated successfully";
                gvDetails.EditIndex = -1;
                BindEmployeeDetails();
            }
            protected void gvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
            {
                gvDetails.EditIndex = -1;
                BindEmployeeDetails();
            }
            protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
                int userid = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["UserId"].ToString());
                string username = gvDetails.DataKeys[e.RowIndex].Values["UserName"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Employee_Details where UserId=" + userid, con);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result == 1)
                {
                    BindEmployeeDetails();
                    lblresult.ForeColor = Color.Red;
                    lblresult.Text = username + " details deleted successfully";
                }
            }
            protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    TextBox txtUsrname = (TextBox)gvDetails.FooterRow.FindControl("txtftrusrname");
                    TextBox txtCity = (TextBox)gvDetails.FooterRow.FindControl("txtftrcity");
                    TextBox txtDesgnation = (TextBox)gvDetails.FooterRow.FindControl("txtftrDesignation");
                    con.Open();
                    SqlCommand cmd =
                    new SqlCommand(
                    "insert into Employee_Details(UserName,City,Designation) values('" + txtUsrname.Text + "','" +
                    txtCity.Text + "','" + txtDesgnation.Text + "')", con);
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result == 1)
                    {
                        BindEmployeeDetails();
                        lblresult.ForeColor = Color.Green;
                        lblresult.Text = txtUsrname.Text + " Details inserted successfully";
                    }
                    else
                    {
                        lblresult.ForeColor = Color.Red;
                        lblresult.Text = txtUsrname.Text + " Details not inserted";
                    }
                }
            }
        }
    }
         
    
                                    
               
                
