     public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if(!IsPostBack)
                {
                    TextBox1.Text = "Text box 1 value";
                    TextBox2.Text = "Text box 2 value";
                    TextBox3.Text = "password";
                }                
            }    
            protected void btnSearch_Click(object sender, EventArgs e)
            {     
                string SearchTerm = txtSearch.Text;   
                string textValue1 = TextBox1.Text, textValue2 = TextBox2.Text, textValue3 = TextBox3.Text;
            }
        }
 
