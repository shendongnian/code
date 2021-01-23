    using System;
    using System.Windows;
    using MySql.Data.MySqlClient;
    namespace Deportes_WPF
    {
    
    public partial class Login : Window
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string user;
        private string password;
        private string port;
        private string connectionString;
        private string sslM;
        public Login()
        {
            InitializeComponent();
            server = "server_name";
            database = "database_name";
            user = "user_id";
            password = "password";
            port = "3306";
            sslM = "none";
           
            connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);
            connection = new MySqlConnection(connectionString);
        }
        private void conexion()
        {
            try
            {
                connection.Open();
                MessageBox.Show("successful connection");
                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + connectionString);
            }
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            conexion();
        }
    }
