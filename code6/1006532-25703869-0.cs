            SqlCommand findProcutsByPattern = new SqlCommand(
                "SELECT *" +
                "FROM [Products]" +
                "WHERE ProductName LIKE @pattern", connection);
            string patternEscaped = pattern.Replace("_", "[_]");
            patternEscaped = patternEscaped.Replace("%", "[%]");
            patternEscaped = patternEscaped.Replace("[", "[[]");
            findProcutsByPattern.Parameters.AddWithValue("@pattern", '%' + patternEscaped + '%');
