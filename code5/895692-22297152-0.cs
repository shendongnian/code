            string idu = string.Empty;
            string value = string.Empty;
            foreach (var item in listamicizie1.ValueMember)
            {
                for (int j = 0; j < listamicizie1.Items.Count; j++)
                {
                    idu = listamicizie1.SelectedValue;
                    value += idu + ",";
                }
            }
            //value = value.TrimEnd(',');
            //value = value.TrimEnd(',');
            value = value.Replace(',', '');
            idutente = user.Text;
            string CnnStr = System.Configuration.ConfigurationSettings.AppSettings["CnnStr"].ToString();
            string querysql2 = " INSERT INTO AMICIZIA (IdUtente1, idamici) VALUES ('" + @idutente,  @value)";
            SqlConnection myconn = new SqlConnection(CnnStr);
            SqlCommand mycmd = new SqlCommand(querysql2, myconn);
            try
            {
                myconn.Open();
                mycmd.Parameters.AddWithValue("@idutente", idutente);
                mycmd.Parameters.AddWithValue("@value", value);
                mycmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                myconn.Close();
            }
        }
        this.Close();
    }
