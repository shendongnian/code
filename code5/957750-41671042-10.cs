    public partial class page : System.Web.UI.Page
    {
     protected void Page_Init(object sender, EventArgs e)
     {
      string txt="<div>blala [slide_plugins /] blabla</div>";
      icerikLtrl.Text = modul_islemler.modul_olustur(txt);
     }
