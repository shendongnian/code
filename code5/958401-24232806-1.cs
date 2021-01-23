     SqlCommand sqlCommand = new SqlCommand("select * from cats",sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            CustomReader customReader = new CustomReader(reader);
            List<Cat> list = new List<Cat>();
            while (customReader.Read())
            {
                Cat cat = new Cat();
                cat.Id = customReader.GetString("id");
                cat.Name = customReader.GetString("name");
                list.Add(cat);    
            }
