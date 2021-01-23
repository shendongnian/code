    public partial class Admin_Login : System.Web.UI.Page
    {
      protected void Page_Load(object sender, EventArgs e)
        {
        
        }
        SqlConnection con = null;
       ConectionStrings cs = new ConectionStrings();
       SqlCommand comm = null;
       SqlDataReader reader = null;
     SqlDataAdapter da;
      protected void btnadmin_login_Click(object sender, EventArgs e)
      {
       
       
            con = new SqlConnection(cs.Db);
            con.Open();
            //string logincheck = "select * from Admin_login where admin_name =@username and admin_pwd=@password";
          string login = " Select * from Admin_login where admin_name = '" + txtadmin_name.Text + "' and admin_pwd = '" + txtadmin_pwd.Text + "' ";
            comm=new SqlCommand(login,con);
    //    comm.Parameters.AddWithValue("@username", txtadmin_name.Text);
    //        //  da = new SqlDataAdapter(login, con);
    //    comm.Parameters.AddWithValue("@admin_pwd", txtadmin_pwd.Text.Trim());
    //
        reader = comm.ExecuteReader();
           if (reader.Read())
            {
               
                Response.Redirect("Admin Add_Books.aspx");
              
           }
           else
           {
               ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
           }
           
            con.Close();
      }
     }
