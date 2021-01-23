        public void AddParameters(string query, List<object> valueList)
        {
            int orderNr = 0;
            string newQuery = Regex.Replace(query, @"(?<Operator>=|<=|>=|<|>)\s?(?<PlaceHolder>:)(?<ColumnName>([A-Za-z0-9\-]+))",
                new MatchEvaluator(
                    delegate(Match match)
                    {
                        var param = this.ProviderFactory.CreateParameter();
                        param.ParameterName = match.Groups["ColumnName"].Value;
                        param.DbType = GetDbType(valueList[orderNr]);
                        param.Value = valueList[orderNr++];
                        Parameters.Add(param);
                        if (ProviderType == DbProviderType.SqlServer)
                            return string.Format("{0}@{1}", match.Groups["Operator"].Value, match.Groups["ColumnName"]); 
                        return match.Value;
                    }
            ));
        }
        private DbType GetDbType(object value)
        {
            if (value is int)
                return DbType.Int32;
            else if (value is double)
                return DbType.Double;
            else if (value is string)
                return DbType.String;
            else 
                return DbType.DateTime;
        }
