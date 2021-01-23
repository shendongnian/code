    int rating = 0;
    if (int.TryParse(tbRating.Text, out rating))
        cmd.Parameters.Add("@websiteRating", SqlDbType.Int).Value = rating;
    else
        cmd.Parameters.Add("@websiteRating", SqlDbType.Int).Value = DBNull.Value;
    
