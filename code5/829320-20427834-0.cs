    public static object GetValueOrNull(this object value)
            {
                return value == DBNull.Value ? null : value;
            }
    string myString DataSet.Tables[0].Rows[0]["DBNullString"].GetValueOrNull();
