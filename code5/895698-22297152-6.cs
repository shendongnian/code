            string CnnStr = System.Configuration.ConfigurationSettings.AppSettings["CnnStr"].ToString();
            string querysql2 = " INSERT INTO AMICIZIA (IdUtente1, idamici) VALUES ('" + @idutente,  @value)";
            SqlConnection myconn = new SqlConnection(CnnStr);
            SqlCommand mycmd = new SqlCommand(querysql2, myconn);
            myconn.Open();
            for (int i=0; i < listamicizie1.Items.Count; i++)
            {
                var myitem = listamicizie1.Items[i];
                var dataArray = ( myitem as DataRowView).Row.ItemArray;
                //MessageBox.Show(dataArray[0].ToString());
                idutente = user.Text; //I don't know what are you storing here.
                value = dataArray[0].ToString(); //dataArray[0] should have key
                try
                {
                  mycmd.Parameters.AddWithValue("@idutente", idutente);
                  mycmd.Parameters.AddWithValue("@value", value);
                  mycmd.ExecuteNonQuery();
                  mycmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.ToString());
                   return;
                }
                finally
                {
                  myconn.Close();
                }
            }
