     public partial class ToErase : System.Web.UI.Page
        {
            private Car myCar;
            protected void Page_Load(object sender, EventArgs e)
            {
                this.myCar = new Car();
                this.myCar.Color = "Black";
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                this.myCar.Color = "Blue"; ////You can access it here
                //Have access to myCar.Color here;
                Response.Write(this.myCar.Color);
            }
        }
        public class Car
        {
            public string Color { get; set; }
        }
