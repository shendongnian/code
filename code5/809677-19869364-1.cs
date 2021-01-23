    // This is your main class.
    namespace WindowsFormsApplication1
    {
       public partial class Form1 : Form
       {
           public Form1()
           {
              InitializeComponent();
           }
           private void SomeMethod(object sender, EventArgs e)
           {
              ConnectToSql connToSql = new ConnectToSql(); // Instantiate the new class here.
              connToSql.SqlConnection();  // Use the new class
           }
       }   
    }
    // This is the class that manages your SqlCommand and connection objects
    namespace WindowsFormsApplication1
    {
       class ConnectToSql
       {
          public void SqlConnection()
          {
             try
             {
                string strConn = "Some connection string here.";
                string strCmd = "Some Sql query string here.";
                
                // Create your connection object.
                using (SqlConnection sqlConn = new SqlConnection(strConn))
                {
                    // Create your command object and pass it the connection.
                    using (SqlCommand sqlCommand = new SqlCommand(strCmd, sqlConn))
                    {
                        sqlConn.Open();
                        // Do some work here.
                        sqlConn.Close();
                    }
                }
             }
             catch (SqlException sqlExc)
             {
                throw;
             }
             catch (Exception exc)
             {
                throw;
             }
         }
    }
