    using (var con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename='C:\\Users\\aayush\\Documents\\Visual Studio 2010\\WebSites\\JustDial\\App_Data\\Database.mdf';Integrated Security=True;User Instance=True"))
    using(var cmd = new SqlCommand("select 1 from shop where UserID=@UserID", con))
    {
        con.Open();
        cmd.Parameters.AddWithValue("@UserID", TextBox2.Text);
        using (var dr = cmd.ExecuteReader())
        {
           if (dr.HasRows)
           {
              Label1.Text = "userid already exists";
           }
           else
           {
              Label1.Text = "userid doesn't exists";
              //Create new user
           }
       }
    }
