    public partial class Input : System.Web.UI.Page{
            protected void btn_Click(object sender, EventArgs e){
                Product product = new Product(txt.Text);
            }
    }
