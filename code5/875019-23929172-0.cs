    public partial class Registerwebpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                SqlConnection conn = new           SqlConnection(ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString);
                conn.Open();
                string checkuser = "select count(*) from [Table1] where Username='" + TextBoxUN.Text + "'";
                SqlCommand com = new SqlCommand(checkuser, conn);
                Int32 count = Convert.ToInt32(com.ExecuteScalar().ToString());
               
                if (count == 1)
                {
                    Response.Write("user already exists");
                }
                conn.Close();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString);
                conn.Open();
                string insertquery = " insert into [Table1] (username,email,password,country) values (@uname,@email,@password,@country) ";
                SqlCommand com = new SqlCommand(insertquery, conn);
                com.Parameters.AddWithValue("@uname", TextBoxUN.Text);
                com.Parameters.AddWithValue("@email", TextBoxEmail.Text);
                com.Parameters.AddWithValue("@password", TextBoxPass.Text);
                com.Parameters.AddWithValue("@country", DropDownListCountry.SelectedItem.ToString());
                com.ExecuteNonQuery();
                Response.Redirect("RegisterDatabase.aspx");
                Response.Write("registration is successful");
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("error:" + ex.ToString());
            }
        }
    }
}
