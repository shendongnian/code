            try
            {
                SQLconn.Open();
               
                string req = "select distinct CapaciteTotal from Avion where NomAvion=" + DropDownList1.Text + "";
                SqlCommand com = new SqlCommand(req, SQLconn);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    TextBox1.Text = dr.GetValue(1).ToString();
                    if (DropDownList4.Text == "Aller Retour")
                    {
                        TextBox2.Text = dr.GetValue(1).ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                HttpContext.Current.Response.Write("<script>alert('Probleme de la base de donnee : " + ex.Message + "')</script>");
            }
            finally
            {
                SQLconn.Close();
            }
           
        }
