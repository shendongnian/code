    <%@ Master Language="C#" AutoEventWireup="true"
        CodeBehind="Site.Master.cs" Inherits="DemoWebForm.Site" %>
    
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <body>
        <form id="form1" runat="server">
            <asp:Label runat="server" ID="MessageLabel" />
            <asp:ContentPlaceHolder ID="MainContent" runat="server">
            </asp:ContentPlaceHolder>
        </form>
    </body>
    </html>
    
    public partial class Site : System.Web.UI.MasterPage
    {
        public string MessageLabelText
        {
            get { return MessageLabel.Text; }
            set { MessageLabel.Text = value; }
        }
    }
