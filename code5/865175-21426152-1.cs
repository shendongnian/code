    public partial class WebForm1 : System.Web.UI.Page
        {
            public int HasCar { get; set; }
    
            protected void Page_Load(object sender, EventArgs e)
            {
                HasCar = 1;
            }
        }
