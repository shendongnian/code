    public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                Image1.ImageUrl = "../images/sc/tiraje.jpg";
                
                Image Image2 = new Image();
                Image2.ImageUrl = "../images/sc/tiraje.jpg";
                PlaceHolder1.Controls.Add(Image2);
            }
        }
