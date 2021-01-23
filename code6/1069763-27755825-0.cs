     Simply do it like this.
 
    namespace Test
          {
        public partial class TestWebForm : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
        
            }
        
            protected void Button1_Click(object sender, EventArgs e)
            {
                int number = int.Parse(txtNumber.Text);
                Response.Write(IsPrime(number));
        
            }
        
            private bool IsPrime(int number){
                int boundary = Math.Floor(Math.Sqrt(number));
        
                if (number == 1) return false;
                if (number == 2) return true;
        
                for (int i = 2; i <= boundary; ++i)  {
                   if (number % i == 0)  return false;
                }
        
                return true;  
            }
        }
        
        }
