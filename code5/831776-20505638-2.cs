    // <summary>
        // Function to translate the StartsWith, EndsWith and Contains canonical functions to LIKE expression in T-SQL
        // and also add the trailing ESCAPE '~' when escaping of the search string for the LIKE expression has occurred
        // </summary>
        private static void TranslateConstantParameterForLike(
            SqlGenerator sqlgen, DbExpression targetExpression, DbConstantExpression constSearchParamExpression, SqlBuilder result,
            bool insertPercentStart, bool insertPercentEnd)
        {
            result.Append(targetExpression.Accept(sqlgen));
            result.Append(" LIKE ");
            // If it's a DbConstantExpression then escape the search parameter if necessary.
            bool escapingOccurred;
            var searchParamBuilder = new StringBuilder();
            if (insertPercentStart)
            {
                searchParamBuilder.Append("%");
            }
            searchParamBuilder.Append(
                SqlProviderManifest.EscapeLikeText(constSearchParamExpression.Value as string, false, out escapingOccurred));
            if (insertPercentEnd)
            {
                searchParamBuilder.Append("%");
            }
            var escapedSearchParamExpression = constSearchParamExpression.ResultType.Constant(searchParamBuilder.ToString());
            result.Append(escapedSearchParamExpression.Accept(sqlgen));
            // If escaping did occur (special characters were found), then append the escape character used.
            if (escapingOccurred)
            {
                result.Append(" ESCAPE '" + SqlProviderManifest.LikeEscapeChar + "'");
            }
        }
