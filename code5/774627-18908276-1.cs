        for (int i = 0; i < 10; i++)
        {
            DoAPIWork();
			Thread.Sleep(4000);
        }
		
		private void DoAPIWork()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=*****;Integrated Security=true;"))
			{
				movie = api.GetMovieInfo(i);
					
					if (string.IsNullOrEmpty(movie.title))
						continue;
					string queryString = string.Format("insert into movie values ('{0}')", movie.title);
					SqlCommand command = new SqlCommand(queryString, connection);
					try
					{
						connection.Open();
						command.ExecuteNonQuery();
						connection.Close();
					}
					catch (Exception ex)
					{
						Debug.WriteLine(ex.Message);
					}
			}
        }
