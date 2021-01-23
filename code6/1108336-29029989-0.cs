    a freind told me to remove my repeater and asign the values in the reader and works ty for the help evryone here is the solution 
    
     SqlConnection conn3 = new SqlConnection();
            conn3.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString;
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.CommandText = "select_forside";
            cmd3.Connection = conn3;
           //  cmd3.Parameters.Add("@login", SqlDbType.Decimal).Value = Session["login"];
    
            conn3.Open();
            SqlDataReader reader3 = cmd3.ExecuteReader();
             // Lav en reader som reader alt ud, billede title og rating
            // og så knyt det til dine forskellige ellementer som Lables og Image
            // Det bliver selvfølgelig et problem hvis du skal have flere end en, for så skal du bruger en repeater
            // og jeg ved ikke hvordan man kan kode bagved til at checke stjerne antallet
    
            if (reader3.Read())
            {
                int stardisplay = (int)Math.Round(Convert.ToDecimal(reader3["film_rating"]), 0);
    
                // display rating
                rating_panel_display.Visible = true;
    
                forside_img.ImageUrl = "images/plakater/"+ reader3["bill_sti"] +"";
                forside_h2.Text = "" + reader3["film_navn"] + "";
                forside_p.Text = "" + reader3["film_beskr"] + "";
                film_rating.Text = "" + reader3["film_rating"] + "";
    
    
                // hvis rating = 1
                if (stardisplay == 1)
                {
                    star6.Visible = true;
                }
    
                // hvis rating = 2
                if (stardisplay == 2)
                {
                    star6.Visible = true;
                    star7.Visible = true;
                }
    
                // hvis rating = 3
                if (stardisplay == 3)
                {
                    star6.Visible = true;
                    star7.Visible = true;
                    star8.Visible = true;
                }
    
                // hvis rating = 4
                if (stardisplay == 4)
                {
                    star6.Visible = true;
                    star7.Visible = true;
                    star8.Visible = true;
                    star9.Visible = true;
                }
    
                // hvis rating = 5
                if (stardisplay == 5)
                {
                    star6.Visible = true;
                    star7.Visible = true;
                    star8.Visible = true;
                    star9.Visible = true;
                    star10.Visible = true;
                }
            }
            conn3.Close();
