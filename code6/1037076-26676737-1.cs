    <%@ Control Language="C#" AutoEventWireup="true" 
        CodeBehind="GridSql.ascx.cs" Inherits="DemoWebForm.GridSql" %>
    <asp:Label runat="server" ID="SearchTextLabel"/>
    
    public partial class GridSql : System.Web.UI.UserControl
    {
        public void SearchTextMethod(string searchText)
        {
            SearchTextLabel.Text = searchText;
        }
    }
