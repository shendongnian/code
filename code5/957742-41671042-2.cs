    public partial class page : System.Web.UI.Page
    {
     protected void Page_Init(object sender, EventArgs e)
     {
      string txt="<div>blala [slide_plugins /] blabla</div>";
      icerikLtrl.Text = modul_islemler.modul_olustur(txt);
     }
    plugins/slide_plugins/slide_plugins.ascx
    
    <asp:TextBox runat="server" ID="Txt1"></asp:TextBox>
    <asp:Button runat="server" ID="btn1" OnClick="btn1_Click" Text="Submit"></asp:Button>
