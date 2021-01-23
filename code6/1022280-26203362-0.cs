        List<SqlParameter> parameterList = new List<SqlParameter>()
            {
                new SqlParameter("@Title", SqlDbType.VarChar) {Size = 30, Value = adminTest.Title},
                new SqlParameter("@Text", SqlDbType.VarChar) {Size = 30, Value = adminTest.Text},
                new SqlParameter("@Questions", SqlDbType.Structured) {TypeName = "dbo.QuestionList", Value = questions}
            };
