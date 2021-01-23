    DataTable tblKeyWords = new DataTable();
    using(var con = new SqlConnection("..."))
    using(var da = new SqlDataAdapter("SELECT FK_NormalizedKeyword FROM KeywordSpelling WHERE Spelling = @keywordspelling", con))
    {
        da.SelectCommand.Parameters.AddWithValue("@keywordspelling", "...");
        da.Fill( tblKeyWords );
    }
