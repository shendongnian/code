    try{
       SqlCommand cmd = new SqlCommand("Delete from [Users] where [UserName]=@User", con);
       cmd.Parameters.Add("@User", SqlDbType.NChar, 20, user);
       cmd.ExecuteNonQuery();
    }catch(Exception ex)
    {
       System.Console.WriteLine( "  ERROR:" + ex.Message );
    }
