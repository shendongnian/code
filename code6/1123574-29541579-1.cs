    using (var conn = new SqlConnection("CONN_STR"))
    {
        IList<State> states = conn
            .Query<State>(
                "select * States where CountryCode = @CountryCode",
                new { CountryCode = countryCode })
            .ToList();
    }
