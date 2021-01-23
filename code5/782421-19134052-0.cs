        public DataSet SearchTable()
        {
            string sqlStatement = "SELECT * from dbo.Documents1";
            bool flag = false;
            var reference = "something"; // txtRef.Text
            var subject = "something else"; // txtSubject.Text
            var sqlCommand = new SqlCommand();
            
            if (!string.IsNullOrWhiteSpace(reference))
            {
                var referenceParameter = new SqlParameter("@referenceParam", SqlDbType.VarChar, 100) { Value = reference };
                sqlCommand.Parameters.Add(referenceParameter);
                sqlStatement += AddWhereLike("Ref", "@referenceParam", flag);
                flag = true;
            }
            if (!string.IsNullOrWhiteSpace(subject))
            {
                var subjectParameter = new SqlParameter("@subjectParam", SqlDbType.VarChar, 100) { Value = reference };
                sqlCommand.Parameters.Add(subjectParameter);
                sqlStatement += AddWhereLike("Subject", "@subjectParam", flag);
                flag = true;
            }
            sqlStatement += " order by Received_Date";
            sqlCommand.CommandText = sqlStatement;
            // do your database reading here
        }
        private static string AddWhereLike(string columnName, string paramId, bool isFirstWhereCondition)
        {
            var whereCondition = isFirstWhereCondition ? " where " : " and " + columnName + "LIKE N'%" + paramId + "%' ";
            return whereCondition;
        }
