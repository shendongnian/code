    if (v.Published != null)
    {
        _strSQL += "Published = @PUBLISHED ,";
        SqlParameter published = new SqlParameter("@PUBLISHED", SqlDbType.DateTime);
        published.Value = v.Published;
        addParameter(command, published); // you have to create an overload of `addParameter()` taking 2 arguments : `DbCommand` and `SqlParameter`
    }
