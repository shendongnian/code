    protected void ButtonOpretbruger_Click(object sender, EventArgs e)
    {
       string fejl = "Hov Hov, Du skal læse vore betingelser";
       if (CheckBoxBetingelser.Checked)
       {
          LabelError.Visible = false;
          using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
          {
              conn.Open();
              using (SqlCommand cmd = new SqlCommand())
              {
                  cmd.Connection = conn;
                  string brugernavn = System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(TextBoxBrugernavn.Text);
                  cmd.CommandText = "SELECT Id, brugernavn, rank FROM brugere WHERE brugernavn = @brugernavn";
                  cmd.Parameters.AddWithValue("@brugernavn", brugernavn);
                  using (SqlDataReader reader = cmd.ExecuteReader())
                  {
                      if (reader.Read())
                      {
                         LabelErrorBesked.Text = "Hov hov, denne her email er optaget " + brugernavn;
                      }
                      else
                      {
                         using (SqlCommand cmd1 = new SqlCommand())
                         {
                             cmd1.Connection = conn;
                             string adgangskode = Hash.getHashSha256(TextBoxAdgangskode.Text);
                             string fornavn = TextBoxFornavn.Text;
                             string efternavn = TextBoxEfternavn.Text;
                             cmd1.CommandText = @"INSERT INTO brugere (brugernavn, adgangskode, fornavn, efternavn) 
                               VALUES (@brugernavn, @adgangskode, @fornavn, @efternavn);";
                             cmd1.Parameters.Add("@brugernavn", brugernavn);
                             cmd1.Parameters.Add("@adgangskode", adgangskode);
                             cmd1.Parameters.Add("@fornavn", fornavn);
                             cmd1.Parameters.Add("@efternavn", efternavn);
                             cmd1.ExecuteNonQuery();
                         }
                         Response.Redirect("login.aspx");
                      }
                  }
               }
            }
            conn.Close();
          }
       else
       {
          LabelError.Text = fejl;
       }
    }
