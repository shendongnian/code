    public partial class Info : System.Web.UI.Page
    {
        SqlCommand Command=null;
        protected void Page_Load(object sender, EventArgs e)
        {
    
    
            if (IsPostBack)
            {
          SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlDataSource1"].ConnectionString);
                Connection.Open();
                string checkuser = "select count(*) from products where UserName='"+txtName.Text+"'";
                 
                 //If you dont want to declare globally , remove below comment
               // SqlCommand Command = new SqlCommand(checkuser,Connection);
    
                int temp = Convert.ToInt32(Command.ExecuteScalar().ToString());
                if (temp == 1)
                {
                    Response.Write("User Eneter invalid value ");
    
                }
    
    
                Connection.Close(); 
    
    
            }
        }
        protected void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
    
                if (IsPostBack)
                {
                   SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlDataSource1"].ConnectionString);
                    Connection.Open();
                    string insert = "insert into products (ID,FirstName,LastName) values (@User,@F,@L)";
                    Command = new SqlCommand(insert, Connection);
                    Command.Parameters.AddWithValue("@User", txtID);
                    Command.Parameters.AddWithValue("@F", txtName);
                    Command.Parameters.AddWithValue("@L", txtLast);
                    Command.ExecuteNonQuery();
                    Response.Redirect("Info.aspx");
                    Response.Write("Connection Sucssesfull");
    
                    Connection.Close();
    
                }
    
    
    
            }
    
            catch (Exception ex)
            {
                Response.Write("Error" + ex.ToString());
            }
        }
    
    }
