    SqlCommand genreSelect = new SqlCommand(@"
             select Genre 
             FROM filmGenres fG INNER JOIN filmGenreTable fGT ON fG.[GenreID] = fGT.[GenreID] 
             WHERE (fGT.[filmID] = @ID2)", connection);
    selectQuery.Parameters.AddWithValue("@ID2", filmID);
    using (SqlDataReader reader1 = selectQuery.ExecuteReader())
    {
        while (reader1.Read())
        {
            genres.InnerText += reader1[0].ToString() + "&nbsp";
        }
    }
    connection.Close();
