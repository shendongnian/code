    public List<dynamic> GetData()
        {
            var resultset = ConvertToDictionary(GetResultReport());
            var result = new List<dynamic>();
            foreach (var emprow in resultset)
            {
                var row = (IDictionary<string, object>)new ExpandoObject();
                Dictionary<string, object> eachRow = (Dictionary<string, object>)emprow;
                foreach (KeyValuePair<string, object> keyValuePair in eachRow)
                {
                    row.Add(keyValuePair);
                }
                result.Add(row);
            }
            return result;
        }
