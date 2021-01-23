    //SessionsCinema start
                inscmd = new SqlCommand();
                inscmd.CommandText = "Insert into SessionsCinema (SessionTime, movie, hall, price) values(@SessionTime, @movie, @hall, @price); select id = @@IDENTITY from SessionsCinema";
                inscmd.Connection = conn;
                inscmd.Parameters.Add("@SessionTime, SqlDbType.NVarChar, 250).Value = SessionTime;
                inscmd.Parameters.Add("@movie", SqlDbType.NVarChar, 250).Value = movie;
                inscmd.Parameters.Add("@hall", SqlDbType.NVarChar, 250).Value = hall;
                inscmd.Parameters.Add("@price", SqlDbType.NVarChar, 250).Value = price;
                adapter = new SqlDataAdapter(inscmd);
                adapter.InsertCommand = inscmd;
                adapter.Update(SessionsCinema);
    //SessionsCinema end
