        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //creating a new connection to the database
                SqlConnection con = new SqlConnection("Data Source=STUDENT-  PC;Initial Catalog=BuyBid;Integrated Security=True;Asynchronous  Processing=True;");
                con.Open();
                //creates a new sqlcommand to update the buyers information to the   Database.
                SqlCommand cmd = new SqlCommand("UPDATE BUYER SET Name = @Name,Surname  = @Surname,Email =@Email,CellNumber =@CellNumber WHERE Email =@Email", con);
			//con.Open();
    
                cmd.Parameters.AddWithValue("@Name", txtNameUpdate.Text);
                cmd.Parameters.AddWithValue("@Surname", txtSurnameUpdate.Text);
                cmd.Parameters.AddWithValue("@Email", txtemailUpdate.Text);
                cmd.Parameters.AddWithValue("@CellNumber", txtCellUpdate.Text);
                cmd.BeginExecuteNonQuery();
		
      			con.Close();
            }
        }
        catch (Exception e)
        {
			Console.WriteLine("Exception occured: " + e.StackTrace);
        }
    }
