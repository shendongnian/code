      string connstr = "....";     
      string query = "insert into Recipes(RecipeName,RecipeImage,RecipeIngredients,RecipeInstructions) " + 
              "values (@name, @pic, @ing, @instr)";
      using(SqlConnection conn = new SqlConnection(connstr))
      using(SqlCommand cmd = new SqlCommand(query, conn))
      {
        conn.Open();
        SqlParameter picparameter = new SqlParameter();
        picparameter.SqlDbType = SqlDbType.Image;
        picparameter.ParameterName = "@pic";
        picparameter.Value = picbyte;
        cmd.Parameters.Add(picparameter);
        cmd.Parameters.AddWithValue("@name", textbox1.Text);
        cmd.Parameters.AddWithValue("@ing", textbox2.Text);
        cmd.Parameters.AddWithValue("@instr", textbox3.Text);
        cmd.ExecuteNonQuery();
        MessageBox.Show("Image successfully saved");
      }
