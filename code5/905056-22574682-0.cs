    public static SqlParameter[] createProblemStatement(params dynamic[] test)
    {
        var lstParam = new List<SqlParameter>();
    
        foreach (var item in test)
        {
            var paramType = item.GetType();
            if (paramType == typeof(string))
            {
                //Do something.
                lstParam.Add(obj);
            }
            else if (paramType == typeof(int))
            {
                //Do something.
                lstParam.Add(obj);
            }
    
        }
        return lstParam.ToArray();
    }
