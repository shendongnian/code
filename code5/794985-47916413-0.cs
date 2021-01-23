    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    
    
    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        bool blnLoginOK = false;
        //Verbindung zur DB herstellen
        SqlConnection conDBTodo = new SqlConnection(ConfigurationManager.ConnectionStrings["conStrLogin"].ConnectionString);
        //SqlCommand vorbereiten, Verbindung zur Tabelle
        SqlCommand comDemoSelect = new SqlCommand();
        comDemoSelect.Connection = conDBTodo;
        //comDemoSelect.CommandType = comm
        comDemoSelect.CommandText = "SELECT ID FROM tabUser WHERE Email=@Email AND Passwort=@Passwort";
        comDemoSelect.Parameters.AddWithValue("@Email", this.txtMail.Text);
        comDemoSelect.Parameters.AddWithValue("@Passwort", this.txtPW.Text);
        comDemoSelect.Connection.Open();
        //Datareader um Daten anzuzeigen
        SqlDataReader drTodo = comDemoSelect.ExecuteReader();
        //Datenausgabe in Labelfeld mit Datareader
        blnLoginOK = drTodo.HasRows; //Sind Datensätze vorhanden?
        //Schliessen aller Verbindungen
        drTodo.Dispose();
        drTodo.Close();
        comDemoSelect.Dispose();
        comDemoSelect.Connection.Close();
        conDBTodo.Dispose();
        conDBTodo.Close();
        if (blnLoginOK == true)
        {
            Session["LoggedIn"] = "true";
            Response.Redirect("Secure.aspx");
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
    protected void btnReg_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registration.aspx");
    }
    protected void btnWeg_Click(object sender, EventArgs e)
    {
            //Verbindung zur DB herstellen
            SqlConnection conDBTodoDelete = new SqlConnection(ConfigurationManager.ConnectionStrings["conStrLogin"].ConnectionString);
            //SqlCommand vorbereiten, Verbindung zur Tabelle mit SQL - Befehl
            SqlCommand comDemoDelete = new SqlCommand("DELETE FROM tabUser WHERE Email = @Email AND Passwort = @Passwort");
            comDemoDelete.Connection = conDBTodoDelete;
            comDemoDelete.Parameters.AddWithValue("@Email", this.txtMail.Text);
            comDemoDelete.Parameters.AddWithValue("@Passwort", this.txtPW.Text);
            comDemoDelete.Connection.Open();
            comDemoDelete.ExecuteNonQuery();
            comDemoDelete.Connection.Close();
            comDemoDelete.Dispose();
            conDBTodoDelete.Dispose();
            conDBTodoDelete.Close();
            txtMail.Text = "Sie haben nun Ihren Account gelöscht!";
            return;
        
    }
}
