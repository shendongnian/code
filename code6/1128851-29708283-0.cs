    private void btnconectar_Click(object sender, EventArgs e) {
      if (!(empty(boxlogin.Text) || empty(boxsenha.Text))) {
        using (SqlCommand cmd = new SqlCommand("SELECT nome, login, senha from Usuarios where login = @Login and senha = @Senha", connection)) {
          cmp.Parameters.AddWithValue("@Login", boxlogin.Text);
          cmp.Parameters.AddWithValue("@Senha", boxsenha.Text);
          cmd.CommandType = CommandType.Text;
          cmd.CommandTimeout = 15; 
          connection.Open();
          using (SqlDataReader reader = cmd.ExecuteReader()) {
            if (reader.Read()) {
              nome =  reader["nome"].ToString();
              login = reader["login"].ToString();
              senha = reader["senha"].ToString();
              msg("Login realizado com sucesso!\nBem vindo(a), " + nome.Substring(0, nome.IndexOf(" ")),Color.Green, false);
              timer4.Start();
            } else {
              msg("Usuário e/ou senha incorretos!", Color.Red, false);
            }
          }
        } else {
          msg("Os campos não podem ficar em branco!", Color.Red, false);
        }
      }
      connection.Close();
    }
