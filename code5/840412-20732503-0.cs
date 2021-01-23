        // I strongly suggest to explicitly name your fields in this select query. Using the asterisk can cause problems if the table structure changes.
        string selectComments = "SELECT * FROM Comment WHERE Comment.EntryID = @EntryID";
        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(selectComments, conn);
        cmd.Parameters.AddWithValue("@EntryID", Session["EntryID"].ToString());
        try
        {
            conn.Open();
            // HERE I WANT TO CALL A LOOP FOR COMMENTS
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // create the div to wrap around the comment
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("style", "commentBody");
                // create three labels and add them to the div
                // 1,2,3 are the ordinal positions of the column names, this may need corrected since I have no idea what your table looks like.
                div.Controls.Add(new Label() { Text = reader.GetString(1) });
                div.Controls.Add(new Label() { Text = reader.GetString(2) });
                div.Controls.Add(new Label() { Text = reader.GetString(3) });
                // add the div to the page somehow, these can be added to any HTML control that can act as a container. I would suggest a plain old div.
                MyMainDiv.Controls.Add(div);
            }
        }
        catch (Exception ex)
        {
            Response.Write("Hata: " + ex.Message);
        }
        finally
        {
            conn.Close();
        }
