    using (var connection = new SqlConnection(...))
    {
        using (var command = new SqlCommand(...))
        {
            using (var reader = command.ExecuteReader(...))
            {
                ...
            }
        }
    }
