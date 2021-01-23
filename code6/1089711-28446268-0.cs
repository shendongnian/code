    private void btnAceptarLogin_Click(object sender, RoutedEventArgs e)
        {
            
            
            SqlConnection conexion  = new SqlConnection();
            conexion.ConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=dolphinsplendidus_Plataforma1; Data Source=. \SQLEXPRESS";
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT [Usuario], [Password] FROM [DatosUsuarios]";
            comando.Connection = conexion;
            SqlDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                string usuarioDatosUsuarios = lector["Usuario"].ToString();
                string passwordDatosUsuarios = lector["Password"].ToString();
                string usuarioLogin = usuariosTextBox.Text;
                string passwordLogin = passwordTextBox.Text;
                if (usuarioLogin == usuarioDatosUsuarios && passwordLogin == passwordDatosUsuarios)
              {
                  MessageBox.Show("Bienvenido " + usuarioLogin);
                  VentanaPrueba venPrueba = new VentanaPrueba();
                  venPrueba.ShowDialog();
                 
              }
              else
              {
                  
                  MessageBox.Show("Introduzca un usuario y contraseña valido y/o contactese con el administrador");
                  
              }
            }
            
        }
