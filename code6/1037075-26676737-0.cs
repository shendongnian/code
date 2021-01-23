    <%@ Control Language="C#" AutoEventWireup="true" 
        CodeBehind="Search.ascx.cs" Inherits="DemoWebForm.Search" %>
    <asp:TextBox runat="server" ID="SearchTextBox" />
    <asp:Button runat="server" ID="SearchButton" 
        Text="Search" OnClick="SearchButton_Click" />
    
    public delegate void MessageHandler(string searchText);
    
    public partial class Search : System.Web.UI.UserControl
    {
        public event MessageHandler SearchText;
    
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            SearchText(SearchTextBox.Text);
        }
    }
